---
title: "Clipboard Change Notification"
page-title: "Clipboard Change Notification - Bars Reference"
order: 12
---
# Clipboard Change Notification

The [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) optionally can raise an event whenever Windows indicates that the contents of the Windows clipboard have changed.

This is useful for any application that uses an `"Edit.Paste"` command since you can enable or disable it based on the contents of the clipboard.

## Enabling Clipboard Change Notifications

To enable clipboard change notifications, set the [ClipboardChangedNotificationEnabled](xref:@ActiproUIRoot.Controls.Bars.BarManager.ClipboardChangedNotificationEnabled) property on the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) to `true`.  When enabled, the [ClipboardChanged](xref:@ActiproUIRoot.Controls.Bars.BarManager.ClipboardChanged) event will be raised whenever the clipboard contents change.  Place code in the event handler to make whatever updates are appropriate to command enabled states.

Keep this property `false` if the functionality is not needed since it uses system resources to track the clipboard change.
