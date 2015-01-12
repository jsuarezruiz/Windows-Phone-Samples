using Ejemplo_LongListSelector.Common;
using Ejemplo_LongListSelector.Model;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Ejemplo_LongListSelector.ViewModels
{
    public class MainPageViewModel
    {
        #region Privates

        private List<Telehpone> _telephones;

        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            _telephones = new List<Telehpone>();
            _telephones.Add(new Telehpone() { Name = "Nokia Lumia 700", OS = "Windows Phone" });
            _telephones.Add(new Telehpone() { Name = "Nokia Lumia 800", OS = "Windows Phone" });
            _telephones.Add(new Telehpone() { Name = "Nokia Lumia 620", OS = "Windows Phone" });
            _telephones.Add(new Telehpone() { Name = "Nokia Lumia 820", OS = "Windows Phone" });
            _telephones.Add(new Telehpone() { Name = "Nokia Lumia 920", OS = "Windows Phone" });
            _telephones.Add(new Telehpone() { Name = "HTC Titan", OS = "Windows Phone" });
            _telephones.Add(new Telehpone() { Name = "HTC 8S", OS = "Windows Phone" });
            _telephones.Add(new Telehpone() { Name = "HTC 8X", OS = "Windows Phone" });
            _telephones.Add(new Telehpone() { Name = "Samsung Galaxy S", OS = "Android" });
            _telephones.Add(new Telehpone() { Name = "Samsung Galaxy S2", OS = "Android" });
            _telephones.Add(new Telehpone() { Name = "Samsung Galaxy S3", OS = "Android" });
            _telephones.Add(new Telehpone() { Name = "Sony Xperia S", OS = "Android" });
            _telephones.Add(new Telehpone() { Name = "Sony Xperia U", OS = "Android" });
            _telephones.Add(new Telehpone() { Name = "HTC Desire", OS = "Android" });
            _telephones.Add(new Telehpone() { Name = "HTC One S", OS = "Android" });
            _telephones.Add(new Telehpone() { Name = "HTC One X", OS = "Android" });
            _telephones.Add(new Telehpone() { Name = "HTC Sensation XL", OS = "Android" });
            _telephones.Add(new Telehpone() { Name = "iPhone 4", OS = "IOS" });
            _telephones.Add(new Telehpone() { Name = "iPhone 4S", OS = "IOS" });
            _telephones.Add(new Telehpone() { Name = "iPhone 5", OS = "IOS" });
        }

        #endregion

        #region Properties

        public List<Telehpone> Telephones
        {
            get { return _telephones; }
        }

        public List<Group<Telehpone>> TelephonesGrouped
        {
            get
            {
                IEnumerable<Group<Telehpone>> groupList = from item in _telephones
                                                  group item by item.OS into g
                                                  orderby g.Key
                                                  select new Group<Telehpone>(g.Key, g);

                return groupList.ToList();
            }
        }

        #endregion
    }
}
