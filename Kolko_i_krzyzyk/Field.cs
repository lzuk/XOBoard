using System.Windows.Forms;

namespace Kolko_i_krzyzyk
{
    class Field
    {
        public Field(Button button)
        {
            Button = button;
            FieldStatus = FieldStatus.Empty;
        }
        public Button Button { get; private set; }
        public FieldStatus FieldStatus { get; set; }
    }
}
