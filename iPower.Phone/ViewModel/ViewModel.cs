using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace iPower.Phone.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        #region Fields
     
        private bool _IsLoading = true;
        
        #endregion
  
        #region Properties
     
        public bool IsLoading
        {
            get { return _IsLoading; }

            set
            {
                base.Set(ref this._IsLoading, value);
            }
        }
       
        #endregion

    }
}
