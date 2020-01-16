# mmfont.Net
.Net library for converting between Unicode :left_right_arrow: Zawgyi

[![AppVeyor Build status](https://ci.appveyor.com/api/projects/status/f4b13no00qkurlrf?svg=true)](https://ci.appveyor.com/project/mgthantzin/mmfont-net) [![Travis CI Build Status](https://travis-ci.org/mgthantzin/mmfont.Net.svg?branch=master)](https://travis-ci.org/mgthantzin/mmfont.Net)

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

## Warning

This is not a fully functional library. Instead, it's just a starter with lots of rooms for improvement.
