﻿namespace CocodriloDog.App {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEditor;

	/// <summary>
	/// Stores prefabs that will be instantiated when the app boots. This must reside in a
	/// Resources folder.
	/// </summary>
	/// 
	/// <remarks>
	/// Normally, the first scene of a unity project should contain all the objects that will 
	/// live for all the lifecycle of the app. This asset has a reference to those objects and
	/// It can be assigned to a <see cref="BootInstantiator"/> in the first scene of the
	/// Unity project, but it will also instantiate the prefabs automatically if the developer
	/// runs the project from other scene. This automation in performed in the
	/// <c>BootPrefabsEditor</c>.
	/// </remarks>
	[CreateAssetMenu(menuName = "Cocodrilo Dog/App/Boot Prefabs")]
	public class BootPrefabs : ScriptableObject {


		#region Public Properties

		/// <summary>
		/// How many prefabs are referenced?
		/// </summary>
		public int PrefabsCount {
			get { return m_Prefabs.Count; }
		}

		#endregion


		#region Public Methods

		/// <summary>
		/// Instantiates the prefabs.
		/// </summary>
		/// <returns>An array with the clones.</returns>
		public GameObject[] InstantiatePrefabs() {
			List<GameObject> clones = new List<GameObject>(PrefabsCount);
			for(int i = 0; i < PrefabsCount; i++) {
				clones.Add(InstantiatePrefabAt(i));
			}
			return clones.ToArray();
		}

		/// <summary>
		/// Instantiates the prefab at the <paramref name="index"/>
		/// </summary>
		/// <param name="index"></param>
		/// <returns>The prefab.</returns>
		public GameObject InstantiatePrefabAt(int index) {
			GameObject original = m_Prefabs[index];
			GameObject clone = Instantiate(original);
			clone.name = original.name;
			return clone;
		}

		/// <summary>
		/// Gets the prefab at the <paramref name="index"/>
		/// </summary>
		/// <param name="index"></param>
		/// <returns>The prefab.</returns>
		public GameObject GetPrefabAt(int index) {
			return m_Prefabs[index];
		}

		#endregion


		#region Private Fields

		[SerializeField]
		private List<GameObject> m_Prefabs;

		#endregion


	}

}