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

namespace OpenWeatherMapApi.Utilities.Singletons {
	/// <summary>
	/// Use this class if you want your access to be around Class.Instance.
	/// </summary>
	/// <typeparam name="T">where T is a class-type and can be instatiated using the 'new' keyword.</typeparam>
	public abstract class Singleton<T> where T : Singleton<T>, new() {
		private static T _instance = null;
		private static object _mutex = new object(); // shared static memory

		/// <summary>
		/// Returns the Singleton Instance.
		/// </summary>
		public static T Instance {
			get {
				lock(Singleton<T>._mutex) {
					if(Singleton<T>._instance == null) {
						Singleton<T>._instance = new T();
					}
				}

				return Singleton<T>._instance;
			}
		}

		protected virtual void Init() { }
	}

	/// <summary>
	/// Use this class if you want static methods on your class.
	/// </summary>
	/// <typeparam name="T">where T is a class-type and can be instatiated using the 'new' keyword.</typeparam>
	public abstract class Internal<T> where T : Internal<T>, new() {
		private static T _instance = null;
		private static object _mutex = new object(); // shared static memory

		/// <summary>
		/// Returns the Singleton Instance.
		/// </summary>
		protected static T Instance {
			get {
				lock(Internal<T>._mutex) {
					if(Internal<T>._instance == null) {
						Internal<T>._instance = new T();
					}
				}

				return Internal<T>._instance;
			}
		}

		protected virtual void Init() { }
	}
}
