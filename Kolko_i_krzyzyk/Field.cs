using System.Windows.Forms;

namespace Kolko_i_krzyzyk
{
    class Field
    {
        public Field()
        {
            FieldStatus = FieldStatus.Empty;
        }
        public Button Button { get; set; }
        public FieldStatus FieldStatus { get; set; }
    }
}
