using System;
using System.Collections.Generic;
using System.Text;

namespace UserControls
{
    public interface IVWAUserControlBase
    {
        //IWVAUserControlBase parent
       // { get; set; }
        void Init(DateTime firstDayOfWeek);
        void LoadData();
        void SaveData();
        bool ValidateData();
		int AutoRun(string param);
        bool IsActive
        {
            get;
            set;
        }
        void LeaveSheet();
    }
}
