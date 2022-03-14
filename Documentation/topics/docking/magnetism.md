---
title: "Magnetism"
page-title: "Magnetism - Docking & MDI Reference"
order: 9
---
# Magnetism

The Dock controls have optional magnetism features that take effect when dragging and resizing undocked tool windows, as well as documents in the MDI area (standard MDI mode only).

When magnetism is active, any undocked tool windows or standard MDI documents that are dragged will attempt to "snap" their corners to other nearby window corners.  If a corner is not found nearby, then the dragged window will attempt to align to the edge of another nearby window instead.  This makes it very easy for the end user to align windows in a column or row.  Additionally, the resizing of windows will also use magnetism to "snap" edges to the location of other nearby window edges.

## Magnetism Configuration

There are a couple of members on the on the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) component that configure how magnetism works:

<table>
<thead>

<tr>
<th>Member</th>
<th>Description</th>
</tr>

</thead>
<tbody>

<tr>
<td>

[MagnetismGapDistance](xref:@ActiproUIRoot.Controls.Docking.DockManager.MagnetismGapDistance) Property

</td>
<td>

Gets or sets the distance between windows that are snapped together via magnetism.

If this value is greater than `0`, there will be a gap between windows that are snapped together when magnetism is enabled by the [MagnetismSnapDistance](xref:@ActiproUIRoot.Controls.Docking.DockManager.MagnetismSnapDistance) property.

</td>
</tr>

<tr>
<td>

[MagnetismSnapDistance](xref:@ActiproUIRoot.Controls.Docking.DockManager.MagnetismSnapDistance) Property

</td>
<td>

Gets or sets the distance at which magnetism begins to snap windows being dragged.

If this value is greater than `0`, magnetism is enabled.  Set it to `0` to disable magnetism.  Increase this property's value to increase the range over which the magnetism will work.

</td>
</tr>

</tbody>
</table>
