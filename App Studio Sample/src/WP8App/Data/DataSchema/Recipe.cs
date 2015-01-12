using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoWapp.ViewModel.Base;

namespace DoWapp.Data
{
    public class Recipe : BindableBase
    {
		public Guid Id { get; set; }
        private string _Continent;
        public string Continent
        {
            get { return _Continent; }
            set
            {
                SetProperty(ref _Continent, value);
            }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                SetProperty(ref _Name, value);
            }
        }
        private string _Instructions;
        public string Instructions
        {
            get { return _Instructions; }
            set
            {
                SetProperty(ref _Instructions, value);
            }
        }
        private string _Ingredients;
        public string Ingredients
        {
            get { return _Ingredients; }
            set
            {
                SetProperty(ref _Ingredients, value);
            }
        }
        private string _Image;
        public string Image
        {
            get { return _Image; }
            set
            {
                SetProperty(ref _Image, value);
            }
        }
        private bool _Vegan;
        public bool Vegan
        {
            get { return _Vegan; }
            set
            {
                SetProperty(ref _Vegan, value);
            }
        }
        private int _Calories;
        public int Calories
        {
            get { return _Calories; }
            set
            {
                SetProperty(ref _Calories, value);
            }
        }
        private int _PrepartionTime;
        public int PrepartionTime
        {
            get { return _PrepartionTime; }
            set
            {
                SetProperty(ref _PrepartionTime, value);
            }
        }
    }
}
