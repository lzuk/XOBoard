namespace Kolko_i_krzyzyk
{
    public class Player
    {
        public static Player Instance
        {
            get { return instance ?? (instance = new Player()); }
        }
        public void ChangePlayer()
        {
            if (ActualPlayer == FieldStatus.X)
            {
                ActualPlayer = FieldStatus.O;
            }
            else
            {
                ActualPlayer = FieldStatus.X;
            }
            OnChanged(ActualPlayer);
        }
        public delegate void PlayerChanged(FieldStatus actualPlayer);
        public event PlayerChanged Changed;
        protected virtual void OnChanged(FieldStatus actualPlayer)
        {
            if (Changed != null)
                Changed(actualPlayer);
        }
        public void RestartGame()
        {
            ActualPlayer = FieldStatus.X;
            OnChanged(ActualPlayer);
        }
        public FieldStatus ActualPlayer {get; private set;}

        private Player()
        {
            ActualPlayer = FieldStatus.X;
        }

        private static Player instance;
    }
}
