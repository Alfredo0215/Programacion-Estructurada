using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE26A_FSA_
{
    public partial class DlgMesaPracticas4 : Form
    {







     












































        /**************************************************************************
  *                            PROYECTO IA                                 *
  **************************************************************************/
        const int SPECIES_RED = 1;
        const int SPECIES_BLUE = 2;
        const int SPECIES_YELLOW = 3;
        const int DEFAULT_FOOD_ENERGY = 5;
        const int MOVEMENT_COST = 35;

        const int BLUE_FOOD_ENERGY = 8;

        const double RED_REPRODUCTION_BONUS = 0.10;

        const double YELLOW_REPRODUCTION_PENALTY = -0.10;

        const int DEFAULT_ENERGY_COST = 1;

        const int YELLOW_ENERGY_SAVE_CHANCE = 50;
        const int ROWS = 30;
        const int COLS = 30;
        const int REPRODUCTION_ENERGY = 10;
        const int REPRODUCTION_COST = 2;
        const int CHILD_START_ENERGY = 8;
        const int CELL_SIZE = 20;

        int[,] energy = new int[ROWS, COLS];
        bool[,] food = new bool[ROWS, COLS];
        double[,] reproductionRate = new double[ROWS, COLS];
        double[,] mutationRate = new double[ROWS, COLS];
        bool[,] moved = new bool[ROWS, COLS];
        Random random = new Random();
        List<int> populationHistory = new List<int>();
        List<int> redHistory = new List<int>();

        List<int> blueHistory = new List<int>();

        List<int> yellowHistory = new List<int>();

        int currentPopulation = 0;

        int totalBirths = 0;

        int totalDeaths = 0;

        double averageEnergy = 0;

        double averageReproductionRate = 0;
        int redPopulation = 0;
        int bluePopulation = 0;
        int yellowPopulation = 0;
        int[,] species = new int[ROWS, COLS];










        /**************************************************************************
  *                            PROYECTO                                    *
  **************************************************************************/

        
        











        public DlgMesaPracticas4()
        {
            InitializeComponent();
            this.DoubleBuffered = true;














            // Proyecto IA
            Helper.DrawHelper.RedondearBoton(BtnProyectoFinal, 20);
            Helper.DrawHelper.RedondearBoton(BtnProyectoFinalIA, 20);
            PbxLogo1.SizeMode = PictureBoxSizeMode.Zoom;
            Helper.DrawHelper.RedondearBoton(PnlCardProyectos, 20);
            Helper.DrawHelper.RedondearBoton(PnlCardSecundario, 20);
            Helper.DrawHelper.RedondearBoton(BtnIniciar, 20);
            Helper.DrawHelper.RedondearBoton(BtnReset, 20);
            InitializeWorld();
            SeedPopulation(20);
            ConfigureGrid();
            DgvMatriz1.Visible = false;

            //ObtenerDatos(numeroElementos, PnlVisualizer.Height, "random");
            elementos = new int[numeroElementos];
            generacionActual = "Random";

            ConfigurarArray(
                numeroElementos,
                PnlVisualizer.Height,
                generacionActual
            );

            PnlVisualizer.Paint += PnlVisualizer_Paint; 



            //DrawWorld();


        }

      
      

        // Variables Globales
        int i = 0;
        int j = 0;
        int numeroElementos = 50;
        bool terminado;
        Random numeroRandom = new Random();
        int actualA = -1;
        int actualB = -1;
        bool huboIntercambio;
        int[] elementos;
        int clicks = 0;
        int swaps = 0;
        int minimoActual = 0;
        int indiceActual;
        string algoritmoActual;
        string generacionActual;
        int insertionI = 1;
        int insertionJ = 1;
        int valorActual;
        bool insertando = false;

        // Función que genera un array de numeros de manera random.
        public void generaciónRandom(int[] elementos, int min, int max)
        {

            for (int i = 0; i < elementos.Length; i++)
            {
                elementos[i] = numeroRandom.Next(min, max);
            } 
           

        }

        // Función que genera un array ordenado al revés
        public void generaciónReversa(int[] elementos, int min, int max)
        {
            generaciónRandom(elementos, min, max);

            Array.Sort(elementos);
            Array.Reverse(elementos);
            
        }

        // Bubble sort paso a paso
        public void BubbleSortStep(int[] elementos)
        {
            if (terminado)
                
                return;
            huboIntercambio = false;

            if (j >= elementos.Length - i - 1)
            {
                j = 0;
                i++;
            }

            if (i >= elementos.Length - 1)
            {
                terminado = true;

                actualA = -1;
                actualB = -1;

                return;
            }

            actualA = j;
            actualB = j + 1;

            if (elementos[j] > elementos[j + 1])
            {
                int temporal = elementos[j];

                elementos[j] = elementos[j + 1];

                elementos[j + 1] = temporal;
                swaps++;
                huboIntercambio = true;
            }

            j++;
        }

        public void SelectionSortStep(int[] elementos)
        {
            minimoActual = elementos[i];
            indiceActual = i;

            huboIntercambio = false;

            if (terminado)
            {
                return;
            }

            if ( i == elementos.Length - 1)
            {
                actualA = -1;
                actualB = -1;
                terminado = true;
                return;
            }

            for (int j = i + 1; j < elementos.Length; j++)
            {

                if (elementos[j] < minimoActual)
                {
                    minimoActual = elementos[j];
                    indiceActual = j;
                    actualA = indiceActual;
                    actualB = j;
                    
                }

                if (j == elementos.Length - 1)
                {
                    int temporal = elementos[i];
                    elementos[i] = minimoActual;
                    elementos[indiceActual] = temporal;
                    i++;
                    swaps++;
                    huboIntercambio = true;
                }
            }
        }

        public void InsertionSortStep(int[] elementos)
        {
            if (terminado)
                return;


            if (insertionI >= elementos.Length)
            {
                terminado = true;

                actualA = -1;
                actualB = -1;

                return;
            }

            if (!insertando)
            {
                valorActual = elementos[insertionI];

                insertionJ = insertionI - 1;

                insertando = true;
            }

            actualA = insertionJ;
            actualB = insertionJ + 1;
            if (insertionJ >= 0 && elementos[insertionJ] > valorActual)

            {

                elementos[insertionJ + 1] = elementos[insertionJ];
                swaps++;
                huboIntercambio = true;
                insertionJ--;
            }


            else
            {
                elementos[insertionJ + 1] = valorActual;
                insertionI++;

                insertando = false;

                huboIntercambio = false;
            }
        }
            

            


        // Función que inicializa el array y determina el tipo de generación de array
        private void ObtenerDatos(int numeroElementos, int altoMaximo, string tipoGeneracion)
        {
            elementos = new int[numeroElementos];
           


            switch (tipoGeneracion)
            {
                
                case "random":
                    generaciónRandom(elementos, 1, altoMaximo);
                    break;

                case "reversa":
                    generaciónReversa(elementos, 1, altoMaximo);
                    break;
            }
            
        }

        private void ConfigurarArray(int numeroElementos, int altoMaximo, string generacionActual)
        {
            switch (generacionActual)
            {
                
                case "Random":
                    generaciónRandom(elementos, 1, altoMaximo);
                    break;

                case "Reversa":
                    generaciónReversa(elementos, 1, altoMaximo);
                    break;
            }
            resetearEstado();
        }

        private void resetearEstado()
        {
            i = 0;
            j = 0;

            terminado = false;

            actualA = -1;
            actualB = -1;

            huboIntercambio = false;

            insertionI = 1;
            insertionJ = 1;
            valorActual = 0; ;
            insertando = false;

            swaps = 0;
        }
        // Función que dibuja el array en el panel
       
        private void DibujarArray(Graphics graficos)
        {


            int altoMaximo = PnlVisualizer.Height; //Altura de los rectángulos
            float anchoMaximo = (float)PnlVisualizer.Width / numeroElementos; ; //Ancho de los rectángulos
            

            

            for (int k = 0; k < numeroElementos; k++) 
            {
                Brush brush = Brushes.Black;


                if (terminado)
                {
                    brush = Brushes.Green;
                }
                else if (k == actualA || k == actualB)
                {
                    if (huboIntercambio)
                    {
                        brush = Brushes.Green;
                    }
                    else
                    {
                        brush = Brushes.Red;
                    }
                }
                graficos.FillRectangle(brush, k * anchoMaximo, altoMaximo - elementos[k], anchoMaximo, elementos[k]);

                
            }

            

        }

        //Función que resalta los rectángulos que se están comparando actualmente
        private void ResaltarComparación()
        {

        }

        // Función que maneja el evento paint del panel
        private void PnlVisualizer_Paint(object sender, PaintEventArgs e)
        {
            DibujarArray(e.Graphics);
        }

        //Botón que empieza el timer para el ordenamiento 
        private void BtnOrdenar_Click(object sender, EventArgs e)
        {
           
            if (TimerSort.Enabled)
            {
                TimerSort.Stop();
                CbcAlgoritmos.Enabled = true;
                CbcGeneracion.Enabled = true;
                BtnOrdenar.Text = "Iniciar";
            }
            else
            {
                TimerSort.Start();
                CbcAlgoritmos.Enabled = false;
                CbcGeneracion.Enabled = false;

                BtnOrdenar.Text = "Pausar";

            }
        }

        private void BtnVelocidades_Click(object sender, EventArgs e)
        {
            

            switch (clicks)
            {
               
                case 0: 
                    TimerSort.Interval = 500;
                    BtnVelocidades.Text = "x1";
                    clicks += 1;
                    break;
                case 1:
                    TimerSort.Interval = 250;
                    BtnVelocidades.Text = "x2";
                    clicks += 1;
                    break;
                case 2:
                    TimerSort.Interval = 125;
                    BtnVelocidades.Text = "x3";
                    clicks = 0;
                    break;
            }
            
        }

        private void BtnTimeTravel_Click(object sender, EventArgs e)
        {
            TimerSort.Interval = 1;
        }
        private void TimerSort_Tick(object sender, EventArgs e)
        {

            if (!terminado)
            {
                switch (algoritmoActual)
                {
                    case "Bubble":
                        BubbleSortStep(elementos);
                        break;

                    case "Selection":
                        SelectionSortStep(elementos);
                        break;

                    case "Insertion":
                        InsertionSortStep(elementos);
                        break;
                }
                TbxSwaps.Text = "Número de intercambios: " + swaps.ToString();

                PnlVisualizer.Invalidate();
            }
            else
            {
                CbcAlgoritmos.Enabled = true;
                CbcGeneracion.Enabled = true;
                BtnOrdenar.Text = "Iniciar";
                TimerSort.Stop();
            }
        }

        private void BtnReiniciarSort_Click(object sender, EventArgs e)
        {
            TimerSort.Stop();
            BtnOrdenar.Text = "Iniciar";
            TbxSwaps.Text = "Número de intercambios: " + swaps.ToString();
            
            clicks = 0;
            // ObtenerDatos(numeroElementos, PnlVisualizer.Height, "random");
            ConfigurarArray(
            numeroElementos,
            PnlVisualizer.Height,
            generacionActual
                            );
            PnlVisualizer.Invalidate();

        }

        private void CbcGeneracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            generacionActual = CbcGeneracion.Text;

            ConfigurarArray(numeroElementos, PnlVisualizer.Height, generacionActual);
            PnlVisualizer.Invalidate();

        }

        private void CbcAlgoritmos_SelectedIndexChanged(object sender, EventArgs e)
        {
            algoritmoActual = CbcAlgoritmos.Text;

        }


























































        /**************************************************************************
*                            PROYECTO IA                                 *
**************************************************************************/
        private void BtnPractica1_Click(object sender, EventArgs e)
        {

            //NOTA: La siguiente es una linea simplificada.
            // PnlPracticas1.Visible = !PnlPracticas1.Visible;

            if (PnlPracticas1.Visible)
            {
                PnlPracticas1.Visible = false;
            }
            else
            {
                PnlPracticas1.Visible = true;
                PnlPracticas2.Visible = false;


            }
            LblProyecto2.Text = "   " + BtnProyectoFinal.Text;


        }

        private void BtnPractica2_Click(object sender, EventArgs e)
        {
            if (PnlPracticas2.Visible)
            {
                PnlPracticas2.Visible = false;
            }
            else
            {
                PnlPracticas2.Visible = true;
                PnlPracticas1.Visible = false;

            }
            LblProyecto2.Text = BtnProyectoFinalIA.Text;

        }




        // Función geeneradora de matriz para ejercicios de llenado.
        private void BtnPractica1Pnl1_Click(object sender, EventArgs e)
        {

        }

        //Prepara estado inicial de la simulación.
        void InitializeWorld()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    energy[row, col] = 0;
                    food[row, col] = false;
                    reproductionRate[row, col] = 0;
                    mutationRate[row, col] = 0;
                    species[row, col] = 0;

                }
            }
        }

        // Dibuja la simulación dentro del Data Grid View.
        void DrawWorld()
        {

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (energy[row, col] > 0)
                    {
                        DgvMatriz1[col, row].Value = "O";
                    }
                    else if (food[row, col])
                    {
                        DgvMatriz1[col, row].Value = "F";
                    }
                    else
                    {
                        DgvMatriz1[col, row].Value = "";
                    }
                }
            }
        }


        //Generación de comida
        void GenerateFood()
        {


            int row = Helper.MathHelper.CrearNumeroRandom(0, ROWS);
            int col = Helper.MathHelper.CrearNumeroRandom(0, COLS);

            // Solo generar comida en celdas vacías
            if (energy[row, col] == 0)
            {
                food[row, col] = true;
            }
        }

        // Desgaste de energía
        void UpdateEnergy()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (energy[row, col] > 0)
                    {
                        int energyCost = DEFAULT_ENERGY_COST;

                        // especie amarilla
                        if (species[row, col] == SPECIES_YELLOW)
                        {
                            // 50% de probabilidad de no gastar energía
                            if (random.Next(0, 100) < YELLOW_ENERGY_SAVE_CHANCE)
                            {
                                energyCost = 0;
                            }
                        }

                        energy[row, col] -= energyCost;

                        // Si hay comida, gana energía
                        if (food[row, col])
                        {
                            int foodEnergy = 5;

                            // especie azul
                            if (species[row, col] == SPECIES_BLUE)
                            {
                                foodEnergy = BLUE_FOOD_ENERGY;
                            }

                            energy[row, col] += foodEnergy;

                            food[row, col] = false;
                        }
                    }
                }
            }
        }

        //Eliminar individuos muertos
        void RemoveDead()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (energy[row, col] <= 0)
                    {
                        if (species[row, col] != 0)
                        {
                            totalDeaths++;
                        }

                        energy[row, col] = 0;
                        reproductionRate[row, col] = 0;
                        mutationRate[row, col] = 0;
                        species[row, col] = 0;
                    }
                }
            }
        }
        //Función central del ciclo
        //---------------------------------------------------------------------
        void UpdateWorld()
        {
            ResetMoved();

            for (int i = 0; i < 8; i++)
            {
                GenerateFood();
            }

            MoveIndividuals();

            UpdateEnergy();

            Reproduce();

            RemoveDead();

            UpdateStatistics();

            UpdateLabels();
            ValidateWorld();

           


            //DrawWorld();
            PnlSimulacion.Invalidate();
            PnlGraph.Invalidate();
        }

        //Reinicia la matriz que indica si un individuo ya se movió
        void ResetMoved()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    moved[row, col] = false;
                }
            }
        }

        //Movimiento de individuos
        void MoveIndividuals()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (energy[row, col] > 0 && !moved[row, col])
                    {
                        int direction = FindFoodDirection(row, col);
                        if (direction == -1)
                        {
                            direction = Helper.MathHelper.CrearNumeroRandom(0, 4);
                        }
                        

                        int newRow = row;
                        int newCol = col;

                        switch (direction)
                        {
                            case 0: newRow--; break;
                            case 1: newRow++; break;
                            case 2: newCol--; break;
                            case 3: newCol++; break;
                        }

                        // Verificar límites
                        if (newRow >= 0 && newRow < ROWS &&
                            newCol >= 0 && newCol < COLS)
                        {
                            // Verificar espacio vacío
                            if (energy[newRow, newCol] == 0)
                            {
                                // mover energía
                                energy[newRow, newCol] = energy[row, col];
                                energy[row, col] = 0;

                                // mover reproducción
                                reproductionRate[newRow, newCol] =
                                    reproductionRate[row, col];

                                reproductionRate[row, col] = 0;

                                // mover mutación
                                mutationRate[newRow, newCol] =
                                    mutationRate[row, col];

                                mutationRate[row, col] = 0;

                                species[newRow, newCol] = species[row, col]; 
                                species[row, col] = 0;

                                // marcar nueva posición
                                moved[newRow, newCol] = true;
                                if (random.Next(0, 100) < MOVEMENT_COST)
                                {
                                    energy[newRow, newCol]--;
                                }
                            }
                            else
                            {
                                // no pudo moverse
                                moved[row, col] = true;
                            }
                        }
                        else
                        {
                            // fuera de límites
                            moved[row, col] = true;
                        }
                    }
                }
            }
        }

        int FindFoodDirection(int row, int col)
        {
            int range = 1;

            // especie roja
            if (species[row, col] == SPECIES_RED)
            {
                range = 3;
            }

            for (int distance = 1; distance <= range; distance++)
            {
                // arriba
                if (row - distance >= 0 &&
                    food[row - distance, col])
                {
                    return 0;
                }

                // abajo
                if (row + distance < ROWS &&
                    food[row + distance, col])
                {
                    return 1;
                }

                // izquierda
                if (col - distance >= 0 &&
                    food[row, col - distance])
                {
                    return 2;
                }

                // derecha
                if (col + distance < COLS &&
                    food[row, col + distance])
                {
                    return 3;
                }
            }

            return -1;
        }

        //Función de reproducción de individuos
        void Reproduce()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    // verificar individuo válido
                    if (energy[row, col] >= REPRODUCTION_ENERGY)
                    {
                        double chance = random.NextDouble();

                        double reproductionModifier = 0;

                        // especie roja
                        if (species[row, col] == SPECIES_RED)
                        {
                            reproductionModifier = RED_REPRODUCTION_BONUS;
                        }

                        // especie amarilla
                        if (species[row, col] == SPECIES_YELLOW)
                        {
                            reproductionModifier = YELLOW_REPRODUCTION_PENALTY;
                        }

                        // tasa final
                        double finalRate =
                            reproductionRate[row, col]
                            + reproductionModifier;

                        // limitar rango
                        if (finalRate < 0)
                        {
                            finalRate = 0;
                        }

                        if (finalRate > 1)
                        {
                            finalRate = 1;
                        }

                        // verificar reproducción
                        if (chance <= finalRate)
                        {
                            // dirección aleatoria
                            int direction =
                                Helper.MathHelper.CrearNumeroRandom(0, 4);

                            int newRow = row;
                            int newCol = col;

                            switch (direction)
                            {
                                case 0: newRow--; break;
                                case 1: newRow++; break;
                                case 2: newCol--; break;
                                case 3: newCol++; break;
                            }

                            // verificar límites
                            if (newRow >= 0 && newRow < ROWS &&
                                newCol >= 0 && newCol < COLS)
                            {
                                // verificar espacio vacío
                                if (energy[newRow, newCol] == 0)
                                {
                                    // crear hijo
                                    energy[newRow, newCol] =
                                        CHILD_START_ENERGY;

                                    totalBirths++;

                                    species[newRow, newCol] =
                                        species[row, col];

                                    // heredar reproducción
                                    reproductionRate[newRow, newCol] =
                                        reproductionRate[row, col];

                                    // mutación
                                    double mutation =
                                        (random.NextDouble()
                                        * mutationRate[row, col] * 2)
                                        - mutationRate[row, col];

                                    reproductionRate[newRow, newCol] += mutation;

                                    // limitar rango
                                    if (reproductionRate[newRow, newCol] < 0)
                                    {
                                        reproductionRate[newRow, newCol] = 0;
                                    }

                                    if (reproductionRate[newRow, newCol] > 1)
                                    {
                                        reproductionRate[newRow, newCol] = 1;
                                    }

                                    // heredar mutación
                                    mutationRate[newRow, newCol] =
                                        mutationRate[row, col];

                                    // costo reproducción
                                    energy[row, col] -=
                                        REPRODUCTION_COST;
                                }
                            }
                        }
                    }
                }
            }
        }

        //Creación de población
        void SeedPopulation(int amount)
        {
            int created = 0;

            while (created < amount)
            {
                int row = Helper.MathHelper.CrearNumeroRandom(0, ROWS);
                int col = Helper.MathHelper.CrearNumeroRandom(0, COLS);

                // verificar espacio vacío
                if (energy[row, col] == 0)
                {
                    energy[row, col] = 15;

                    reproductionRate[row, col] = 0.3;

                    mutationRate[row, col] = 0.05;
                    species[row, col] = random.Next(1, 4);

                    created++;
                }
            }
        }
        void ConfigureGrid()
        {
            DgvMatriz1.RowCount = ROWS;
            DgvMatriz1.ColumnCount = COLS;
        }


        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            UpdateWorld();
        }

        private void PnlSimulacion_Paint(object sender, PaintEventArgs e)
        {
            DrawSimulation(e.Graphics);
        }

        void DrawSimulation(Graphics g)
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    int x = col * CELL_SIZE;
                    int y = row * CELL_SIZE;

                    // Dibujar fondo
                    g.DrawRectangle(Pens.LightGray, x, y, CELL_SIZE, CELL_SIZE);

                    // Dibujar comida
                    if (food[row, col])
                    {
                        g.FillRectangle(Brushes.Green, x, y, CELL_SIZE, CELL_SIZE);
                    }

                    // Dibujar individuo
                    if (energy[row, col] > 0)
                    {
                        switch (species[row, col])
                        {
                            case 1:
                                g.FillRectangle(Brushes.Red,
                                    x, y, CELL_SIZE, CELL_SIZE);
                                break;

                            case 2:
                                g.FillRectangle(Brushes.Blue,
                                    x, y, CELL_SIZE, CELL_SIZE);
                                break;

                            case 3:
                                g.FillRectangle(Brushes.Gold,
                                    x, y, CELL_SIZE, CELL_SIZE);
                                break;

                            default:
                                // debug visual
                                g.FillRectangle(Brushes.Black,
                                    x, y, CELL_SIZE, CELL_SIZE);
                                break;
                        }
                    }
                }
            }
        }
        void UpdateStatistics()
        {
            int population = 0;

            int energySum = 0;

            double reproductionSum = 0;
            redPopulation = 0;
            bluePopulation = 0;
            yellowPopulation = 0;

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (energy[row, col] > 0)
                    {
                        population++;
                        switch (species[row, col])
                        {
                            case SPECIES_RED:
                                redPopulation++;
                                break;

                            case SPECIES_BLUE:
                                bluePopulation++;
                                break;

                            case SPECIES_YELLOW:
                                yellowPopulation++;
                                break;
                        }

                        energySum += energy[row, col];

                        reproductionSum += reproductionRate[row, col];
                    }
                }
            }

            currentPopulation = population;

            if (population > 0)
            {
                averageEnergy =
                    (double)energySum / population;

                averageReproductionRate =
                    reproductionSum / population;
            }
            else
            {
                averageEnergy = 0;

                averageReproductionRate = 0;
            }

            populationHistory.Add(population);
            redHistory.Add(redPopulation);

            blueHistory.Add(bluePopulation);

            yellowHistory.Add(yellowPopulation);

            // limitar historial
            if (populationHistory.Count > 120)
            {
                populationHistory.RemoveAt(0);
            }
            if (redHistory.Count > 120)
            {
                redHistory.RemoveAt(0);
            }

            if (blueHistory.Count > 120)
            {
                blueHistory.RemoveAt(0);
            }

            if (yellowHistory.Count > 300)
            {
                yellowHistory.RemoveAt(0);
            }
        }
        void UpdateLabels()
        {
            LblPopulation.Text =
                "Población: " + currentPopulation;

            LblBirths.Text =
                "Nacimientos: " + totalBirths;

            LblDeaths.Text =
                "Muertes: " + totalDeaths;

            LblEnergy.Text =
                "Energía promedio: " +
                averageEnergy.ToString("0.00");

            LblRedPopulation.Text =
    "Rojas: " + redPopulation;

            LblBluePopulation.Text =
                "Azules: " + bluePopulation;

            LblYellowPopulation.Text =
                "Amarillas: " + yellowPopulation;
        }
        void ValidateWorld()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (energy[row, col] > 0 &&
                        species[row, col] == 0)
                    {
                        MessageBox.Show(
                            "Individuo sin especie");
                    }

                    if (energy[row, col] == 0 &&
                        species[row, col] != 0)
                    {
                        MessageBox.Show(
                            "Especie fantasma");
                    }
                }
            }
        }
        void DrawGraph(Graphics g)
        {
            // fondo
            g.Clear(Color.Black);

            

            // evitar errores si no hay suficientes datos
            if (populationHistory.Count < 2)
            {
                return;
            }

            int panelWidth = PnlGraph.Width;
            int panelHeight = PnlGraph.Height;

            // encontrar población máxima
            int maxPopulation = 1;

            foreach (int value in populationHistory)
            {
                if (value > maxPopulation)
                {
                    maxPopulation = value;
                }
            }

            // espacio horizontal entre puntos
            float xStep =
                (float)panelWidth / (populationHistory.Count - 1);


            // dibujar gráfica roja
            DrawSpeciesLine(
                g,
                redHistory,
                Pens.Red,
                maxPopulation,
                panelWidth,
                panelHeight,
                xStep);

            // dibujar gráfica azul
            DrawSpeciesLine(
                g,
                blueHistory,
                Pens.Blue,
                maxPopulation,
                panelWidth,
                panelHeight,
                xStep);

            // dibujar gráfica amarilla
            DrawSpeciesLine(
                g,
                yellowHistory,
                Pens.Gold,
                maxPopulation,
                panelWidth,
                panelHeight,
                xStep);
        }

        void DrawSpeciesLine(
        Graphics g,
        List<int> history,
        Pen pen,
        int maxPopulation,
        int panelWidth,
        int panelHeight,
        float xStep)
        

        {
            int padding = 20;

            float usableWidth =
                panelWidth - padding * 2;

             xStep =
                usableWidth / (history.Count - 1);

            Rectangle graphArea =
            new Rectangle(
            padding,
            padding,
            panelWidth - padding * 2,
            panelHeight - padding * 2);

            int guideLines = 4;

            for (int i = 0; i <= guideLines; i++)
            {
                float y =
                    padding +
                    ((panelHeight - padding * 2)
                    * i / guideLines);

                g.DrawLine(
                    Pens.DimGray,
                    padding,
                    y,
                    panelWidth - padding,
                    y);
            }

            g.SetClip(graphArea);

            for (int i = 1; i < history.Count; i++)
            {
                float x1 = padding + ((i - 1) * xStep);

                float x2 = padding + (i * xStep);

                float y1 =
                    panelHeight - padding -
                    ((float)history[i - 1]
                    / maxPopulation)
                    * (panelHeight - padding * 2);

                float y2 =
                    panelHeight - padding -
                    ((float)history[i]
                    / maxPopulation)
                    * (panelHeight - padding * 2);
                g.DrawLine(
                    pen,
                    x1, y1,
                    x2, y2);
            }
        }

        private void PnlGraph_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph(e.Graphics);
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            if (TimerSimulacion.Enabled)
            {
                TimerSimulacion.Stop();
                BtnIniciar.Text = "Iniciar";
            }
            else
            {
                TimerSimulacion.Start();
                BtnIniciar.Text = "Pausar";
            }
        }
        void ResetSimulation()
        {
            TimerSimulacion.Stop();

            InitializeWorld();

            populationHistory.Clear();

            redHistory.Clear();

            blueHistory.Clear();

            yellowHistory.Clear();

            totalBirths = 0;

            totalDeaths = 0;

            InitializeWorld();

            SeedPopulation(20);

            UpdateStatistics();

            UpdateLabels();

            PnlSimulacion.Invalidate();

            PnlGraph.Invalidate();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetSimulation();
        }

       
    }

    
    }
