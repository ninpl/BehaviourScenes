//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// BehaviourScenes.cs (06/03/2018)												\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Control de la transicion de escena unica					\\
// Fecha Mod:		06/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Control de la transicion de escena unica.</para>
	/// </summary>
	public class BehaviourScenes : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Escena que cargara al inicio.</para>
		/// </summary>
		public string escenaInicial = string.Empty;						// Escena que cargara al inicio
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Todas las escenas de la escena.</para>
		/// </summary>
		private GameObject[] escenas;                                   // Todas las escenas de la escena
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="BehaviourScenes"/>.</para>
		/// </summary>
		private void Start()// Inicializador de BehaviourScenes
		{
			// Agregar todas las escenas de la escena
			escenas = GameObject.FindGameObjectsWithTag("Transicion");

			// Fija la primera escena
			SetEscena(escenaInicial);
		}
		#endregion

		#region API
		public void SetEscena(string escena)
		{

		}
		#endregion
	}
}
