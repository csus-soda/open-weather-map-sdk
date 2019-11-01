using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenWeatherMapApi;
using OpenWeatherMapApi.Core;

namespace MSTest_OpenWeatherMap {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void ValidInitialization() {
			var config = new OpenWeatherMapConfiguration.Builder("").Build();

			OpenWeatherMap.Initialize(config);

			ICurrentWeather result =  OpenWeatherMap.GetCurrentWeather(35, 139);

			Assert.IsNotNull(result);
		}
	}
}
