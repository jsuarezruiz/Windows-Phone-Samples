
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWapp.Data
{
    public class RecipeDataSource : IRecipeDataSource
    {
        public ObservableCollection<Recipe> GetData()
        {

			var data = new ObservableCollection<Recipe>()
            {
              new Recipe()
                {
                    Id= new Guid("8c5a2620-585f-45fb-91a5-034fe53ecea9"),

                    Continent=@"-",
                    Name=@"Tortilla souppppp",
                    Instructions=@"1 If you are starting with somewhat old, dried out tortillas, great.",
                    Ingredients=@"6 corn tortillas preferably a little old and dried out",
                    Image="Mexican_1_600_C.jpg",
                    Vegan=false,
                    Calories=0,
                    PrepartionTime=30,
                },
              new Recipe()
                {
                    Id= new Guid("fa5460b7-ce49-4c45-b83c-524472160f57"),

                    Continent=@"Mexico",
                    Name=@"Taco Salad",
                    Instructions=@"Combine salsa and sour cream in a large bowl. Heat oil in a large nonstick skillet over medium heat. Add onion and garlic and cook, stirring often, until softened, about 2 minutes. Add turkey and cook, stirring often and crumbling with a wooden spoon, until cooked through, about 5 minutes. Add tomatoes, beans, cumin and chili powder; cook, stirring, until the tomatoes begin to break down, 2 to 3 minutes. Remove from the heat, stir in cilantro and 1/4 cup of the salsa mixture. Add lettuce to the remaining salsa mixture in the bowl; toss to coat. To serve, divide the lettuce among 4 plates, top with the turkey mixture and sprinkle with cheese.",
                    Ingredients=@"1/2 cup prepared salsa",
                    Image="Mexican_2_600_C.jpg",
                    Vegan=false,
                    Calories=700,
                    PrepartionTime=30,
                },
              new Recipe()
                {
                    Id= new Guid("e43e79e9-819f-45ad-8125-0b26b4f665a6"),

                    Continent=@"Mexico",
                    Name=@"Taquitos",
                    Instructions=@"Heat the oven to 400?. Heat the oil in a large skillet over medium heat. Add the onion and garlic and cook them for 3 minutes, stirring often. Add the beef and use a wooden spoon or a spatula to break it up while it cooks, until it is no longer red, about 3 minutes. Stir in 1/2 cup of the salsa, the chili powder, and the salt and pepper. Cook the mixture over low heat, stirring occasionally, for 10 minutes. Place the tortillas on a plate and cover them with damp paper towels. Microwave them until warm and pliable, about 45 seconds. Top each tortilla with 1/4 cup of the beef mixture, spreading it to an inch from the edges. Sprinkle cheese evenly over the beef. Roll up the tortillas and place them on a foil-lined baking sheet with the seam sides down. Brush the taquitos lightly with vegetable oil, then bake them until the filling is heated through and the tortillas are lightly browned, about 8 to 12 minutes. Serve them hot with sour cream and/or salsa. Serves 4 to 6.",
                    Ingredients=@"tablespoon vegetable oil plus more for brushing on the taquitos",
                    Image="Mexican_3_600_C.jpg",
                    Vegan=true,
                    Calories=600,
                    PrepartionTime=30,
                },
              new Recipe()
                {
                    Id= new Guid("fab49644-6e93-41dc-8921-bd219f2ac6f5"),

                    Continent=@"Mexico",
                    Name=@"Pulled Pork Enchilada",
                    Instructions=@"Trim fat from pork. In a 3 1/2- or 4-quart slow cooker combine pork shoulder, broth, onion, garlic, cumin, ground chipotle chili pepper or chili powder, and salt. Cover and cook on low-heat setting for 10 to 11 hours or on high-heat setting for 5 to 6 hours. 2. Preheat oven to 400 degrees F. Remove pork from slow cooker, reserving cooking liquid. Using two forks, pull meat into coarse strands. 3. In a large bowl combine pork, 1/2 cup of the enchilada sauce, 2 tablespoons of the reserved cooking liquid, and the 1 tablespoon snipped cilantro. Set aside. 4. In a medium bowl combine the remaining enchilada sauce, 1/4 cup of the reserved cooking liquid (discard any remaining cooking liquid), and the diced green chili peppers. Spread about 1/2 cup of enchilada-green chili pepper mixture in the bottom of a 3-quart rectangular baking dish; set aside. 5. Divide pork mixture and 1 1/2 cups of the cheese among tortillas, placing meat and cheese near the edge of each tortilla. Roll up tortillas. Place filled tortillas, seam sides down, in the prepared baking dish (place tortillas close together); top with the remaining enchilada-green chili pepper mixture. Cover with foil; bake for 25 minutes. Sprinkle with the remaining 1/2 cup cheese. Bake, uncovered, about 5 minutes more or until heated through and cheese is softened and starts to brown slightly.6. Sprinkle with additional snipped cilantro and tomato. If desired, serve with sour cream. Makes 6 servings.",
                    Ingredients=@"3 1/2 pounds boneless pork shoulder, 1 14 ounce can chicken broth, 1/2 cup chopped onion, 6 cloves garlic minced, 1 tablespoon ground cumin, 2 or 3 teaspoons ground chipotle chili pepper or hot chili powder, 1 teaspoon salt, 3 10 ounce cans enchilada sauce, 1 tablespoon snipped fresh cilantro, 1 4 ounce can diced green chili peppers, 8 ounces cotija cheese shredded, 8 inches flour tortillas, Snipped fresh cilantro yDiced tomato or quartered grape tomatoes Sour cream.",
                    Image="Mexican_4_600_C.jpg",
                    Vegan=true,
                    Calories=600,
                    PrepartionTime=30,
                },
              new Recipe()
                {
                    Id= new Guid("c1058a1d-8533-465b-addc-456ce33c3a00"),

                    Continent=@"Mexico",
                    Name=@"Salsa Verde",
                    Instructions=@"1 Remove papery husks from tomatillos and rinse well.2a Roasting method Cut in half and place cut side down on a foil-lined baking sheet. Place under a broiler for about 5-7 minutes to lightly blacken the skin.2b Boiling method Place tomatillos in a saucepan, cover with water. Bring to a boil and simmer for 5 minutes. Remove tomatillos with a slotted spoon.2 Place tomatillos, lime juice, onions, cilantro, chili peppers, sugar in a food processor (or blender) and pulse until all ingredients are finely chopped and mixed. Season to taste with salt. Cool in refrigerator. Serve with chips or as a salsa accompaniment to Mexican dishes. Makes 3 cups.",
                    Ingredients=@"1 1/2 lb tomatillos, 1/2 cup chopped white onion, 1/2 cup cilantro leaves, 1 Tbsp fresh lime juice, 1/4 teaspoon sugar, 2 Jalapeño peppers OR 2 Serrano peppers stemmed seeded and chopped y Salt to taste.",
                    Image="Mexican_5_600_C.jpg",
                    Vegan=true,
                    Calories=600,
                    PrepartionTime=30,
                },
              new Recipe()
                {
                    Id= new Guid("5c5e10b2-e44d-4176-b286-b0a59d0e600f"),

                    Continent=@"-",
                    Name=@"name",
                    Instructions=@"elaboration",
                    Ingredients=@"ingredients",
                    Image="5334b779-d301-4b94-8f57-c686bc094c56.png",
                    Vegan=false,
                    Calories=0,
                    PrepartionTime=22,
                },

            };

            return data;
        }
    }
}

