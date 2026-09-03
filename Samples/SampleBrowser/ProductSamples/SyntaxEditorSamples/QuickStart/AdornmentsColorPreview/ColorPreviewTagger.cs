using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Tagging.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
using System.Text.RegularExpressions;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.AdornmentsColorPreview {

	/// <summary>
	/// Provides <see cref="ColorPreviewTag"/> objects over text ranges that contain the color specifications.
	/// </summary>
	public class ColorPreviewTagger : TaggerBase<ColorPreviewTag> {

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		/// <param name="document">The document to which this manager is attached.</param>
		public ColorPreviewTagger(ICodeDocument document) : base("ColorPreview", orderings: null, document, isForLanguage: true) { }

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Returns the tag ranges that intersect with the specified normalized snapshot ranges.
		/// </summary>
		/// <param name="snapshotRanges">The collection of normalized snapshot ranges.</param>
		/// <param name="parameter">An optional parameter that provides contextual information about the tag request.</param>
		/// <returns>The tag ranges that intersect with the specified normalized snapshot ranges.</returns>
		public override IEnumerable<TagSnapshotRange<ColorPreviewTag>> GetTags(NormalizedTextSnapshotRangeCollection snapshotRanges, object? parameter) {
			if (snapshotRanges is not null) {
				// Loop through the snapshot ranges
				foreach (var snapshotRange in snapshotRanges) {
					// Get the text of the snapshot range
					var text = snapshotRange.Text;

					// Look for a regex pattern match
					var matches = Regex.Matches(text, Pattern, RegexOptions.IgnoreCase);
					if (matches.Count > 0) {
						// Loop through the matches
						foreach (Match match in matches) {
							// Create a tag
							var tag = new ColorPreviewTag() {
								Color = UIColor.FromWebColor(match.Value).ToColor()
							};

							// Ensure full alpha
							if (tag.Color.A < 255)
								tag.Color = Color.FromArgb(alpha: 255, tag.Color.R, tag.Color.G, tag.Color.B);

							// Yield the tag
							yield return new TagSnapshotRange<ColorPreviewTag>(
								TextSnapshotRange.FromSpan(snapshotRange.Snapshot, snapshotRange.StartOffset + match.Index, match.Length),
								tag
							);
						}
					}
				}
			}
		}

		/// <summary>
		/// The regex pattern used to match colors.
		/// </summary>
		protected virtual string Pattern
			=> /* lang=regex */ @"(\#([a-f0-9]{6}|[a-f0-9]{3}|[a-f0-9]{8})\b)|(rgb\(\s*(\d+\%?)\s*,\s*(\d+\%?)\s*,\s*(\d+\%?)\s*\))|(rgba\(\s*(\d+\%?)\s*,\s*(\d+\%?)\s*,\s*(\d+\%?)\s*,\s*(\d(\.\d+)?)\s*\))";

	}

}
