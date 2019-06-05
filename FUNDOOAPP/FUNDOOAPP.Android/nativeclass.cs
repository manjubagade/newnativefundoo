using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FUNDOOAPP.Droid;
using FUNDOOAPP.interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(nativeclass))]


namespace FUNDOOAPP.Droid
{
    class nativeclass: InativeInterface
    {
        public void xamarinnative(string val)
        {
            var intent = new Intent(Forms.Context, typeof(sample));
            intent.PutExtra("noteId", val);
            Forms.Context.StartActivity(intent);
        }
    }
}