// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Touch.Views
{
	[Register ("ContactDetailsView")]
	partial class ContactDetailsView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel FirstnameText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel IdText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel LastnameText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PhoneNumberText { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (FirstnameText != null) {
				FirstnameText.Dispose ();
				FirstnameText = null;
			}
			if (IdText != null) {
				IdText.Dispose ();
				IdText = null;
			}
			if (LastnameText != null) {
				LastnameText.Dispose ();
				LastnameText = null;
			}
			if (PhoneNumberText != null) {
				PhoneNumberText.Dispose ();
				PhoneNumberText = null;
			}
		}
	}
}
