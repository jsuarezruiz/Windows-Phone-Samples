$(function () {

    ///////////////////////////////////////////////////////////////
    // Standard drawing board functionalities
    ///////////////////////////////////////////////////////////////
    var canvas = $("#canvas");
    var colorElement = $("#color");
    var buttonPressed = false;
    canvas
        .mousedown(function () {
            buttonPressed = true;
        })
        .mouseup(function () {
            buttonPressed = false;
        })
        .mousemove(function (e) {
            if (buttonPressed) {
                setPoint(e.offsetX, e.offsetY, colorElement.val());
            }
        });

    var ctx = canvas[0].getContext("2d");
    function setPoint(x, y, color) {
        ctx.fillStyle = color;
        ctx.beginPath();
        ctx.arc(x, y, 2, 0, Math.PI * 2);
        ctx.fill();
    }
    function clearPoints() {
        ctx.clearRect(0, 0, canvas.width(), canvas.height());
    }

    $("#clear").click(function () {
        clearPoints();
    });

    ///////////////////////////////////////////////////////////////
    // SignalR specific code
    ///////////////////////////////////////////////////////////////

    var hub = $.connection.drawingBoard;
    hub.state.color = colorElement.val(); // Accessible from server
    var connected = false;

    // UI events
    colorElement.change(function () {
        hub.state.color = $(this).val();
    });
    canvas.mousemove(function (e) {
        if (buttonPressed && connected) {
            hub.server.broadcastPoint(Math.round(e.offsetX), Math.round(e.offsetY));
        }
    });
    $("#clear").click(function () {
        if (connected) {
            hub.server.broadcastClear();
        }
    });

    // Event handlers
    hub.client.clear = function () {
        clearPoints();
    };
    hub.client.drawPoint = function (x, y, color) {
        setPoint(x, y, color);
    };
    hub.client.update = function (points) {
        for (var x = 0; x < 300; x++) {
            for (var y = 0; y < 300; y++) {
                if (points[x][y]) {
                    setPoint(x, y, points[x][y]);
                }
            }
        }
    };

    // Voila!
    $.connection.hub.start()
        .done(function () {
            connected = true;
        });

});
