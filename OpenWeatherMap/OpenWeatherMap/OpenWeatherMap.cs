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

namespace OpenWeatherMapApi  {
	public sealed partial class OpenWeatherMap : System.Object {
		/// <summary>
		/// Do not use this!
		/// </summary>
		private static volatile OpenWeatherMap instance = null;

		/// <summary>
		/// Sanity checks that instance has been initialized. Throws an exception other wise.
		/// </summary>
		static OpenWeatherMap Instance {
			get {
				if(OpenWeatherMap.instance == null) {
					throw new System.Exception(
						string.Format(
							"{0} - {0} was not initialized! Make sure to call {0}.Initialize({1})",
							typeof(OpenWeatherMap).Name,
							typeof(OpenWeatherMapConfiguration).Name));
				}

				return OpenWeatherMap.instance;
			}
		}

		private readonly string endpoint;
		private readonly OpenWeatherMapConfiguration config;

		private OpenWeatherMap(OpenWeatherMapConfiguration config) {
			this.endpoint = string.Format("http://api.openweathermap.org/data/{0}", config.Version);
			this.config = config;
		}

		/// <summary>
		/// Initialize OpenWeatherMap, this needs to be called before any API calls
		/// can be made. This should only be done once.
		/// </summary>
		/// <param name="config">Configuration for the OpenWeatherMap API.</param>
		public static void Initialize(OpenWeatherMapConfiguration config) {
			if(OpenWeatherMap.instance == null) {
				OpenWeatherMap.instance = new OpenWeatherMap(config);

				return;
			}

			System.Console.WriteLine(
				string.Format(
					"{0} - Initialize(): {0} is already initialized. Ignoring call.",
					typeof(OpenWeatherMap).Name));
		}
	}
}
