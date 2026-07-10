using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CollapsedRegionsAdvanced;

/// <summary>
/// Provides an <see cref="ICollapsedRegionTag"/> implementation that controls collapsed regions.
/// </summary>
public class CollapsedRegionTag : ICollapsedRegionTag, IIntraTextSpacerTag {

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	/// <param name="key">An object that can be used to uniquely identify the spacer.</param>
	public CollapsedRegionTag() {
		// Since the tags in this sample are persisted in a collection while active, the tag will use
		//   itself as the key. The key is used to retrieve the bounds of the spacer later on so adornments
		//   can be rendered in it, thus is must be unique
		Key = this;
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc cref="IIntraTextSpacerTag.Baseline"/>
	public float Baseline { get; set; }

	/// <inheritdoc cref="IIntraTextSpacerTag.IsSpacerBefore"/>
	public bool IsSpacerBefore
		=> true;

	/// <summary>
	/// An object that can be used to uniquely identify the spacer.
	/// </summary>
	public object Key { get; }

	/// <inheritdoc cref="IIntraTextSpacerTag.Size"/>
	public Size Size { get; set; }

	/// <summary>
	/// The text to display.
	/// </summary>
	public string? Text { get; set; }

	/// <summary>
	/// Creates an <see cref="IIntraTextSpacerTag"/>-based tag snapshot range for this tag.
	/// </summary>
	/// <param name="snapshotRange">The <see cref="TextSnapshotRange"/> for the tag.</param>
	public TagSnapshotRange<IIntraTextSpacerTag> ToIntraTextSpacerTagRange(TextSnapshotRange snapshotRange)
		=> new(snapshotRange, tag: this);

}
