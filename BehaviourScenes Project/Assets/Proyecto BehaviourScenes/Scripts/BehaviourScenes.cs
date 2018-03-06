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
		/// <summary>
		/// <para>Cambia la escena a la dada.</para>
		/// </summary>
		/// <param name="escena">Nueva escena.</param>
		public void SetEscena(string escena)// Cambia la escena a la dada
		{
			StartCoroutine(CambiarEscena(escena));
		}
		#endregion

		#region Corrutina
		/// <summary>
		/// <para>Procesamiento</para>
		/// </summary>
		/// <param name="newEscena"></param>
		/// <returns></returns>
		public IEnumerator CambiarEscena(string newEscena)// Procesamiento
		{
			// Bloquear inputs
			gameObject.GetComponent<CanvasGroup>().interactable = false;

			// Ocultar
			Animator animator = gameObject.GetComponent<Animator>();
			animator.SetBool("Hide", true);

			// Esperar a que la animacion termine
			yield return new WaitForSeconds(1);

			// Ocultar todas las escenas
			foreach (GameObject escena in escenas)
			{
				escena.GetComponent<CanvasGroup>().alpha = 0;
				escena.GetComponent<CanvasGroup>().interactable = false;
				escena.GetComponent<CanvasGroup>().blocksRaycasts = false;
			}

			// Activar la nueva escena
			GameObject escenaActiva = GameObject.Find(newEscena);
			escenaActiva.GetComponent<CanvasGroup>().alpha = 1;
			escenaActiva.GetComponent<CanvasGroup>().interactable = true;
			escenaActiva.GetComponent<CanvasGroup>().blocksRaycasts = true;

			// Mostrar canvas
			animator.SetBool("Hide", false);

			// Habilitar inputs
			gameObject.GetComponent<CanvasGroup>().interactable = true;
		}
		#endregion
	}
}
