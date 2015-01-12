
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWapp.Data
{
    public interface IRecipeDataSource
    {
        ObservableCollection<Recipe> GetData();        
    }
}
