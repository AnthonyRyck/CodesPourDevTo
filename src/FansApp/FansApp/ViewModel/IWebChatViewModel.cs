using FansApp.Models;
using FansApp.Services;
using HeyRed.MarkdownSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.ViewModel
{
	public interface IWebChatViewModel
	{
		/// <summary>
		/// Liste de tous les messages reçus.
		/// </summary>
		List<Message> TousLesMessages { get; }

		/// <summary>
		/// Permet de transformer du Markdown to Html
		/// </summary>
		Markdown Markdown { get; }

		/// <summary>
		/// Question à poser à QnAMaker
		/// </summary>
		string Question { get; set; }

		/// <summary>
		/// Indique si un service QnAMaker est configuré.
		/// </summary>
		bool HaveServiceQnAMaker { get; }

		/// <summary>
		/// C'est le dernier message JSON reçu.
		/// </summary>
		string LastMessageJson { get; }

		/// <summary>
		/// Retourne le style CSS si c'est une question ou non.
		/// </summary>
		/// <param name="isQuestion"></param>
		/// <returns></returns>
		string GetClass(bool isQuestion);

		/// <summary>
		/// Retour l'alignement à mettre sur la div.
		/// </summary>
		/// <param name="isQuestion"></param>
		/// <returns></returns>
		string GetAlign(bool isQuestion);

		/// <summary>
		/// Pose une question
		/// </summary>
		/// <param name="question"></param>
		/// <returns></returns>
		Task PoserLaQuestion(string question);

		
	}
}
