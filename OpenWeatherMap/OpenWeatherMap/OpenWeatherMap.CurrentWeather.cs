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
	using Core;
	using System.Net;
	using System.IO;

	public partial class OpenWeatherMap {
		/// <summary>
		/// Gets the current weather based on latitude and longitude. This operation is asyncronous,
		/// requires a callback to get the result.
		///
		/// https://openweathermap.org/current
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		/// <param name="callback">Callback that will receive the a weather object.</param>
		public static void GetCurrentWeatherAsync(double latitude, double longitude, System.Action<IResponse> callback) {
			OpenWeatherMap.GetCurrentWeatherAsync(new Coordinate { Latitude = latitude, Longitude = longitude }, callback);
		}

		/// <summary>
		/// Gets the current weather based on a Coordindate. This operation is asyncronouse,
		/// requires a callack to get the result.
		///
		/// https://openweathermap.org/current
		/// </summary>
		/// <param name="coordinate"></param>
		/// <param name="callback"></param>
		public static void GetCurrentWeatherAsync(Coordinate coordinate, System.Action<IResponse> callback) {
			// TODO: Make REST Api request here...
		}

		/// <summary>
		/// Gets the current weather based on latitude and longitude. This operation is synchronous.
		///
		/// https://openweathermap.org/current
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		/// <returns></returns>
		public static ICurrentWeather GetCurrentWeather(double latitude, double longitude) {
			return OpenWeatherMap.GetCurrentWeather(new Coordinate { Latitude = latitude, Longitude = longitude });
		}

		/// <summary>
		/// Gets the current weather based on a Coordindate. This operation is synchronous.
		/// 
		/// </summary>
		/// <param name="coordinate"></param>
		/// <returns></returns>
		public static ICurrentWeather GetCurrentWeather(Coordinate coordinate) {
			var result = new CurrentWeather();

			// TODO: Make REST Api request here...
			string url = string.Format(
				"{0}/weather?{1}&APPID={2}",
				OpenWeatherMap.Instance.endpoint,
				coordinate.GetQueryFormat(),
				OpenWeatherMap.Instance.config.ApiKey);

			WebRequest request = WebRequest.Create(url);

			using(var response = request.GetResponse()) {
				using(var stream = response.GetResponseStream()) {
					using(var reader = new StreamReader(stream)) {
						System.Console.WriteLine(reader.ReadToEnd());
					}
				}
			}

			return result;
		}

		[System.Serializable]
		class CurrentWeather : ICurrentWeather {
			// TODO: Finish class implementation here...
		}
	}
}
