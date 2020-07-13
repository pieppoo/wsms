using System.Windows.Forms;

namespace WSMS_MASTER.views.Base
{
    public partial class BaseForm : Form
    {
        public string Title
        {
            get { return lblTitle.Text; }
            set
            {
                lblTitle.Text = value;
            }
        }
        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
