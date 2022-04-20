using Newtonsoft.Json.Linq;

namespace SuperDuperBackend
{
    class Solution {
        /// <summary>
        /// Génère une grille de sudoku de difficulté facile
        /// </summary>
        /// <returns>la grille de sudoku</returns>
        public static int[][] GenerateGrille() {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://sugoku2.herokuapp.com/board?difficulty=easy").Result;
                var json = response.Content.ReadAsStringAsync().Result;
                var jsonObject = JObject.Parse(json);
                var grid = jsonObject["board"]!.ToObject<int[][]>();
                return grid;
            }
        }

        public static bool Checknumb(var numy) {
            bool sortir = false;
            int[] num= { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for(int i=0;i<num.Length;i++)
            {
                if (numy == num[i])
                    sortir = true;
            }
            return sortir;
        }

        /// <summary>
        /// Vérifie si le sudoku à été résolu
        /// </summary>
        /// <param name="grille">Grille de sudoku renvoyé par l'utilisateur</param>
        /// <returns>true si la grille est résolue, false sinon</returns>
        public static bool CheckGrille(int[][] grille) {
            bool complete = true;
            for(int i=0;i<grille.Length(0);i++)
            {
                for(int j=0;j<grille.Length(1);j++)
                {
                    if (!Checknumb(grille[i][j]))
                        complete = false;
                }
            }
            return complete;
        }
    }
}