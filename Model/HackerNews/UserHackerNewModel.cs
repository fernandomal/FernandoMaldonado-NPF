using System;

namespace Model
{
    public class UserHackerNewModel
    {
        /// <summary>
        /// The user's unique username. Case-sensitive. Required.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Delay in minutes between a comment's creation and its visibility to other users.
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// Creation date of the user, in Unix Time.
        /// </summary>
        public Int32 Created { get; set; }

        /// <summary>
        /// The user's karma.
        /// </summary>
        public string Karma { get; set; }

        /// <summary>
        /// The user's optional self-description. HTML.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// List of the user's stories, polls and comments.
        /// </summary>
        public int[] Submitted { get; set; }
    }
}
