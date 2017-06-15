# mmfont.Net
.Net library for converting between Unicode and Zawgyi

This library is .Net adaptation ofhttps://github.com/setkyar/mmfont

## Usage

    using mmfont.Net;

    public partial class Main : Form
    {
        private void btnConvert_Click(object sender, EventArgs e)
        {
            txtZawgyi.Text = Converter.Uni2ZG(txtUni.Text);
        }
    }
