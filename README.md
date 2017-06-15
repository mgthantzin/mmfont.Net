# mmfont.Net
.Net library for converting between Unicode and Zawgyi

[![Build status](https://ci.appveyor.com/api/projects/status/f4b13no00qkurlrf?svg=true)](https://ci.appveyor.com/project/mgthantzin/mmfont-net)

## Credit
This library is .Net adaptation of [mmfont by @setkyar](https://github.com/setkyar/mmfont/) who packaged [@saturngod's Rabbit](https://github.com/saturngod/Rabbit) into php.

## Usage

    using mmfont.Net;

    public partial class Main : Form
    {
        private void btnConvert_Click(object sender, EventArgs e)
        {
            txtZawgyi.Text = Converter.Uni2ZG(txtUni.Text);
        }
    }
