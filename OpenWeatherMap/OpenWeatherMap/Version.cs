#region License
// Copyright(c) 2019 Software Developers Association(SoDA)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify,
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be included in all copies
// or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Contact: csus.soda @gmail.com subject - OpenWeatherMap API
#endregion

namespace OpenWeatherMapApi {
	using StringBuilder = System.Text.StringBuilder;

	/// <summary>
	/// Version - Allows the ease of use to interagate Software Versioning for compatability.
	/// </summary>
	public class Version : System.Object {
		private int major = 0;
		private int minor = 0;
		private int patch = 0;
		private TagType tagType;
		private int tagValue;

		private string version;

		/// <summary>
		/// Version constructor
		/// </summary>
		/// <param name="major">Major version, increments indicate API breaking changes.</param>
		/// <param name="minor">Minor version, increments indicate non-breaking API changes. This is backwards compatable.</param>
		/// <param name="patch">Path version, increments indicate optimizations and bugfixes. This is backwards compatable.</param>
		/// <param name="tagType">TagType, indicates what stage this Software is in. Alpha, Beta, Release etc.</param>
		/// <param name="tagValue">Tag Value, increments in Software stage. Is not used if tagType is set to TagType.None.</param>
		public Version(int major, int minor, int patch, TagType tagType, int tagValue) {
			this.major = major;
			this.minor = minor;
			this.patch = patch;
			this.tagType = tagType;
			this.tagValue = tagValue;

			var builder = new StringBuilder();

			if(major >= 0) {
				builder
				.Append(this.Major);
			}

			if(minor >= 0) {
				builder
					.Append(".")
					.Append(this.Minor);
			}

			if(patch >= 0) {
				builder
					.Append(".")
					.Append(this.patch);
			}

			if(tagType != TagType.None) {
				builder.Append("-");

				switch(tagType) {
					case TagType.Alpha:
						builder.Append("a");
						break;
					case TagType.Beta:
						builder.Append("b");
						break;
					case TagType.ReleaseCandidate:
						builder.Append("rc");
						break;
					case TagType.Realease:
						builder.Append("r");
						break;
				}

				builder.Append(this.tagValue);
			}

			this.version = builder.ToString();

			builder.Clear();
		}

		/// <summary>
		/// The major version.
		/// </summary>
		public int Major {
			get {
				return this.major;
			}
		}

		/// <summary>
		/// The minor version.
		/// </summary>
		public int Minor {
			get {
				return this.minor;
			}
		}

		/// <summary>
		/// The patch version.
		/// </summary>
		public int Patch {
			get {
				return this.patch;
			}
		}

		/// <summary>
		/// The TagType for this software version.
		/// </summary>
		public TagType Tag {
			get {
				return this.tagType;
			}
		}

		/// <summary>
		/// The TagValue for this software version.
		/// </summary>
		public int TagValue {
			get {
				return this.tagValue;
			}
		}

		/// <summary>
		/// Returns a default version of 1.0.0
		/// </summary>
		public static readonly Version Default = new Version
			.Builder()
			.Major(1).Minor(0).Patch(0)
			.TagType(TagType.None).TagValue(0)
			.Build();

		public override string ToString() {
			return this.version;
		}

		public enum TagType {
			None = 0,
			Alpha = 1,
			Beta = 3,
			ReleaseCandidate = 4,
			Realease = 5
		}

		public sealed class Builder {
			private int major;
			private int minor;
			private int patch;
			private TagType tagType;
			private int tagValue;

			public Builder() {
				this.major = 0;
				this.minor = 0;
				this.patch = -1;
				this.tagType = Version.TagType.None;
				this.tagValue = 0;
			}

			public Builder Major(int major) {
				this.major = major;

				return this;
			}

			public Builder Minor(int minor) {
				this.minor = minor;

				return this;
			}

			public Builder Patch(int patch) {
				this.patch = patch;

				return this;
			}

			public Builder TagType(TagType tagType) {
				this.tagType = tagType;

				return this;
			}

			public Builder TagValue(int tagValue) {
				this.tagValue = tagValue;

				return this;
			}

			public Version Build() {
				return new Version(this.major, this.minor, this.patch, this.tagType, this.tagValue);
			}
		}
	}
}
