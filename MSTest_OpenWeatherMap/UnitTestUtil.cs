using System.IO;

public static class UnitTestUtil {
	public static readonly string ApiKey = new System.Func<string>(
		() => {
			string apiKey = string.Empty;

			using(var stream = new FileStream("config.ini", FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
				using(var reader = new StreamReader(stream)) {
					string line = null;

					while((line = reader.ReadLine()) != null) {
						var split = line.Split(":");

						if(string.Compare(split[0], "api_key") == 0) {
							apiKey = split[1].Replace(" ", "");
						}
					}
				}
			}

			if(string.IsNullOrEmpty(apiKey)) {
				throw new System.Exception(
					string.Format("Could not extract OpenWeatherMap api key. Make sure you edit the file under /bin/Debug/netcoreapp3.0/config.ini"));
			}
			return apiKey;
		})();
}