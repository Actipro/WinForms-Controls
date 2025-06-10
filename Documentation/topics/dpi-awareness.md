---
title: "DPI Awareness"
page-title: "DPI Awareness"
order: 24
---
# DPI Awareness

Actipro WinForms Controls have been designed to support applications configured for DPI awareness.

## System Awareness vs. Per-Monitor Awareness

System DPI awareness means applications are configured to support the DPI of the primary monitor. If a window is moved to a monitor with a DPI that is different than the primary monitor, the operating system will render the application at system DPI and then scale the image to fit the DPI of the monitor. This can often lead to text and images that appear fuzzy. System DPI awareness works best in single-monitor scenarios or where all monitors are set to the same DPI.

Per-monitor DPI awareness means applications are configured to run on the DPI of the monitor where a window is displayed. If a window is moved to a monitor with a different DPI, the window will be rescaled and rendered at the DPI of the new monitor. This results in clear text and images at most DPI levels, although some images may still not scale with precision.

> [!TIP]
> Per-monitor DPI awareness typically provides the best end-user experience and should be supported when possible.

## Declaring Operating System Support

> [!IMPORTANT]
> Support for DPI awareness is OS-specific and may require your application to explicitly declare support for the related operating system.  Per Monitor V1 requires at least Windows 8.1 and Per Monitor V2 requires at least Windows 10 v1703.

Applications declare supported operating systems using an *app.manifest* file.  Our **Sample Browser** application ships with an *app.manifest* file that can be used as an example.  In general, the following code snippet can be added to the *app.manifest* file to declare support:

```xml
<assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1">
	...
	<compatibility xmlns="urn:schemas-microsoft-com:compatibility.v1">
		<application>
			<!-- A list of the Windows versions that this application has been tested on and is
			is designed to work with. Uncomment the appropriate elements and Windows will
			automatically selected the most compatible environment. -->

			<!-- Windows 7 -->
			<supportedOS Id="{35138b9a-5d96-4fbd-8e2d-a2440225f93a}" />

			<!-- Windows 8 -->
			<supportedOS Id="{4a2f28e3-53b9-4441-ba9c-d69d4a4a6e38}" />

			<!-- Windows 8.1 -->
			<supportedOS Id="{1f676c76-80e1-4239-95bb-83d0f6d0da78}" />

			<!-- Windows 10/11 -->
			<supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}" />

		</application>
	</compatibility>
	...
</assembly>
```

## Known Issues and Limitations

Actipro WinForms Controls target multiple .NET Frameworks, and each target can have drastically different levels of support for DPI awareness. These differences are most prevalent when working with per-monitor DPI awareness. When building DPI awareness for our controls, every effort has been made to support per-monitor DPI awareness, but some scenarios could not be consistently supported.

> [!TIP]
> Per-monitor DPI awareness is still a work-in-progress for Windows Forms, so targeting the latest supported version of .NET is recommended.

> [!IMPORTANT]
> Actipro controls are tested with `PerMonitorV2` only. The original `PerMonitor` configuration version was very limited and has been replaced with `PerMonitorV2` on all versions of Windows still under support. For per-monitor DPI awareness, using `PerMonitorV2` instead of `PerMonitor` is highly recommended.

### Bars

- The Bars customization form may not rescale correctly on some .NET targets when moving between monitors of different DPIs and the application is running with per-monitor DPI awareness.  This primarily impacts .NET 6+.

### Docking

- [DocumentMdiStyle](xref:@ActiproUIRoot.Controls.Docking.DocumentMdiStyle).[Standard](xref:@ActiproUIRoot.Controls.Docking.DocumentMdiStyle.Standard) may not properly clip the child window when maximized in a per-monitor DPI aware environment. If the monitor DPI is higher than the system DPI, part of the window chrome will be visible. If the monitor DPI is lower than the system DPI, part of the client area may be clipped. This issue can be mitigated by using [DocumentMdiStyle](xref:@ActiproUIRoot.Controls.Docking.DocumentMdiStyle).[Tabbed](xref:@ActiproUIRoot.Controls.Docking.DocumentMdiStyle.Tabbed) instead.

### SyntaxEditor

- When using per-monitor DPI awareness and an instance of `SyntaxEditor` is display on more than one monitor with different DPIs, the common images used for IntelliPrompt may have a DPI that does not match the current monitor.
