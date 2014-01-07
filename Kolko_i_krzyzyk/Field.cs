using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kolko_i_krzyzyk
{
    class Field
    {
        public Field(Button button)
        {
            this.Button = button;
            FieldStatus = Kolko_i_krzyzyk.FieldStatus.Empty;
        }
        public Button Button { get; set; }
        public FieldStatus FieldStatus { get; set; }
    }
}
