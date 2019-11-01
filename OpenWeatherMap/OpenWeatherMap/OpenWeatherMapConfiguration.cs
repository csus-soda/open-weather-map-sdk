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
	public class OpenWeatherMapConfiguration : System.Object {
		private string apiKey = string.Empty;
		private Version version = Version.Default;
		private Mode mode;
		private System.TimeSpan cacheTime = System.TimeSpan.Zero;
		private Units units;

		private OpenWeatherMapConfiguration(string apiKey) {
			this.apiKey = apiKey;
		}

		/// <summary>
		/// API key from OpenWeatherMap.org
		/// </summary>
		public string ApiKey {
			get {
				return this.apiKey;
			}
		}

		/// <summary>
		/// Version of the API to be used.
		/// </summary>
		public Version Version {
			get {
				return this.version;
			}
		}

		/// <summary>
		/// The amount of time a query will be cached. This is for speeding up,
		/// result turnaround times and also to not ping the server for redudent data.
		///
		/// https://openweathermap.org/appid
		/// </summary>
		public System.TimeSpan CacheTime {
			get {
				return this.cacheTime;
			}
		}

		/// <summary>
		/// The content-type we want the response to be in.
		/// Json, Xml, Html.
		/// </summary>
		public Mode Mode {
			get {
				return this.mode;
			}
		}

		/// <summary>
		/// The unit type a weather response should be in.
		/// </summary>
		public Units Units {
			get {
				return this.units;
			}
		}

		/// <summary>
		/// A Builder class to help with constructing our
		/// OpenWeatherMapConfiguration object.
		/// </summary>
		public class Builder : System.Object {
			private string apiKey = string.Empty;
			private Version version = new Version.Builder()
				.Major(2).Minor(5).Patch(-1)
				.TagType(global::OpenWeatherMapApi.Version.TagType.None).Build();

			private System.TimeSpan cacheTime = new System.TimeSpan(0, 10, 0);
			private Mode mode = global::OpenWeatherMapApi.Mode.Json;
			private Units units = global::OpenWeatherMapApi.Units.Standard;

			public Builder(string apiKey) {
				this.apiKey = apiKey;
			}

			/// <summary>
			/// The version of the API to be used. 
			/// </summary>
			/// <param name="version"></param>
			/// <returns></returns>
			public Builder Version(Version version) {
				this.version = version;

				return this;
			}

			/// <summary>
			/// The amount of time, certain queries can be cached for.
			/// </summary>
			/// <param name="cacheTime"></param>
			/// <returns></returns>
			public Builder CacheTime(System.TimeSpan cacheTime) {
				this.cacheTime = cacheTime;

				return this;
			}

			/// <summary>
			/// The response type we should expect. Json, Xml, Html.
			/// </summary>
			/// <param name="mode"></param>
			/// <returns></returns>
			public Builder Mode(Mode mode) {
				this.mode = mode;

				return this;
			}

			/// <summary>
			/// The units to be specified by certain API calls.
			/// </summary>
			/// <param name="units"></param>
			/// <returns></returns>
			public Builder Units(Units units) {
				this.units = units;

				return this;
			}

			/// <summary>
			/// Builds a OpenWeatherConfiguration object.
			/// </summary>
			/// <returns></returns>
			public OpenWeatherMapConfiguration Build() {
				var config = new OpenWeatherMapConfiguration(this.apiKey);

				config.version = this.version;
				config.cacheTime = this.cacheTime;
				config.mode = this.mode;

				return config;
			}
		}
	}
}
