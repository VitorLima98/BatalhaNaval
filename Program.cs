using System.ComponentModel.Design;
using System.Runtime.InteropServices;
internal class Program
{
    private static void Main(string[] args)
    {


//variável que define o tamanho do tabuleiro
int max=10;
//coordenadas do ataque, usadas durante a jogada (o valor é só temporário e não entra no codigo)
int x=0, w=-1;
char y='L';
//tabuleiro do jogo
int[,] mapa = new int[max, max];
//condicao de vitoria
int barcos =1, partes=1;
//numero aleatorio
Random rand = new Random();
//variaveis do jogo
int jogadas = (max*max)/2;
//Variaveis dos menus
int op, menu;
//tamanho dos barcos
int [] tam = new int[3];
tam = [1,2,3];
//Mudar encoding de saida pra permitir o 🛥 barquinho (permite utilizar o simbulo do barco)
Console.OutputEncoding = System.Text.Encoding.UTF8;


//MENU PRINCIPAL
//Rótulo menu para o goto vir pra ca
Menu:

//Tela inicial
Console.WriteLine("   ------------====== BATALHA NAVAL!!! ======------------\t");
Console.WriteLine("\n                           __/___\n          \\.|./´     _____/______|\n             _______/_____\\_______\\_____\n             \\              < < <       |      \\.|./´\n    ~~~.~~.~~~.~~..~~~.~~..~~~.~~..~~~.~~..~~~.~~~.~~.~~~ by: Jullya\n");

Console.WriteLine(" 1- JOGAR\n 2- INSTRUÇÕES");

//Menu para o usuario
//try catch serve para evitar que o ato do usuario inserir letras emcerre o programa
try
        {
        menu= int.Parse(Console.ReadLine());        
        }
        catch (FormatException)
        {
            //caso o suario insira letras, aparece a mensagem de invalido e volta pro menu
            Console.WriteLine("Opção inválida!");
            goto Menu;
        }

//switch: executa a opçao dentro do menu, selecionada pelo usuario dependendo do numero
switch(menu){
    case 1:
    // Menu secundario
     Console.WriteLine(" Escolha a dificuldade: ");
     Console.WriteLine(" 1- Fácil\n 2- Médio\n 3- Difícil\n 4- Personalizado");
     //try catch também serve para não deixar o programa encerrar caso o usuario digite letras
     try
        {
        op= int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            //caso o suario insira letras, aparece a mensagem de invalido e volta pro menu
        Console.WriteLine("Opção inválida!");
        goto Menu;
        }

//switch  para escolher dificuldades do jogo
switch(op){
case 1:
Console.WriteLine(" ---------- Nível Fácil ---------- "); //Gravar mensagem na tela
max=5; //tamanho do tabuleiro
jogadas=20; //número de joagdas do nível
barcos=1; //quantidade de barcos do nível
break;
case 2:
Console.WriteLine(" ---------- Nível Médio ---------- ");
max=10;
jogadas=55;
barcos=2;

break;
case 3:
Console.WriteLine(" ---------- Nível Difícil ---------- ");
max=10;
jogadas=45;
barcos=3;

break;
case 4:
    Console.WriteLine(" ---------- Nível Personalizado ---------- ");
    Console.WriteLine(" Escolha o tamanho do mapa: ");
    max= int.Parse(Console.ReadLine());
    Console.WriteLine(" Escolha a quantidade de jogadas: ");
    jogadas= int.Parse(Console.ReadLine());
    Console.WriteLine(" Escolha a quantidade de barcos: ");
    barcos= int.Parse(Console.ReadLine());
    break;
    // caso não seja escolhido nenhuma das opções informadas aparecera a mensagem de opcão invalida
default:
    Console.WriteLine("Opção inválida!");  
    goto Menu; // volta para o menu
    break;
}
    break;
    // Instruções gerais do jogo
    case 2:
    Console.WriteLine("Instruções:\n \n A água é representada por um ( ~ ); Barcos atingidos serão representador por ( 🛥 ) ");
    Console.WriteLine(" Se nenhum barco for atingido um X aparecerá no local;");
    Console.WriteLine(" Você tem uma quantidade limitada de jogadas de acordo com o nível escolhido;");
    Console.WriteLine(" Se o limite de jogadas for ultrapassado, antes da vitória, você perde.\n Bom jogo!");

    goto Menu; // volta para o menu após o usuario seleicionar as instruções
    break;
    // caso não seja escolhido nenhuma das opções informadas aparecera a mensagem de opcão invalida
    default:
    Console.WriteLine("Opção inválida!");
    goto Menu; //volta para o menu
    break;
}


//Instruções de jogadas e tamanho dos barcos
Console.WriteLine("Voce tem "+ jogadas+" jogadas para detonar "+barcos+ " barco(s):");
//foreach informa o tamanho dos barcos para o usuario
foreach (int i in tam){
    if(i<=barcos) Console.WriteLine("1 barco de tamanho " +i);
}
Console.WriteLine("\n\n");

//Método para mostar o mapa do jogo
 void mostrarMapa() {
Console.WriteLine(""); //espaço

//RÓTULO DAS COLUNAS
Console.Write("    ");
//Troca os números das colunas por letras
for (int j = 0; j<max; j++) {
    if(j==0)Console.Write("A  ");
    if(j==1)Console.Write("B  ");
    if(j==2)Console.Write("C  ");
    if(j==3)Console.Write("D  ");
    if(j==4)Console.Write("E  ");
    if(j==5)Console.Write("F  ");
    if(j==6)Console.Write("G  ");
    if(j==7)Console.Write("H  ");
    if(j==8)Console.Write("I  ");
    if(j==9)Console.Write("J  ");
       
} 
Console.WriteLine("");
Console.WriteLine("");

//for para rodar as linhas
for (int i = 0; i<max; i++){
 
 //RÓTULO DAS LINHAS
    Console.Write(i+1+" ");
    if(i<9) Console.Write(" "); //espaço do alinhamento
  //Mostrar icone referente ao valor da matriz
    for (int j = 0; j<max; j++){
        //0 = não tem nada aqui
        //2 = tem um barco aqui, mas você não vê
        //3 = Você acertou o barco e 4 não acertou o barco 
    if (mapa[i,j] == 0) Console.Write(" ~ "); //se não hover barco, mostra o síbulo da água
    //caso termine a partida sem achar os barcos aparecera (O) 
    if (mapa[i,j] == 2 && jogadas>0) Console.Write(" ~ ");
    else if (mapa[i,j] == 2 && jogadas==0) Console.Write(" O ");
    //se o barco for atingido aparecerá o símbulo do barco
    if (mapa[i,j] == 3) Console.Write(" 🛥");
    //se não houver barco aparecerá o X
    if  (mapa[i,j] == 4) Console.Write(" X ");

}
    Console.WriteLine(" ");// espaço
}  }


//Zerar todo o mapa para iniciar o jogo
for (int i = 0; i<max; i++){
    for (int j = 0; j<max; j++){
    mapa[i,j] = 0;
}
}

//Colocar os barcos num lugar aleatorio
for (int p=0; p<barcos; p++){

//GERAR BARCO COM UMA PARTE
//apenas seleciona uma posicao aleatoria e coloca um barco la
if(p==0) mapa[ rand.Next(max-1),rand.Next(max-1) ] = 2; 

//GERAR BARCO COM DUAS PARTES
if(p==1){
    int xt, yt; //variaveis para armazenar a posição inicial da parte do barco

    Gerar: // inicio do goto para gerar duas partes do barcos
    xt= rand.Next(max-1);
    yt= rand.Next(max-1);
    //CHECAR SE JA NAO TEM BARCO LA, se tiver gera de novo
    if (mapa[xt,yt]==0) mapa[xt,yt] = 2;
    else goto Gerar;

    //posicionando segunda parte do barco
    //sortear 50%, para  vertical ou horizontal
    if( rand.Next(0,2)==0 ){
        //gera as dsegunda parte do baco na VERTICAL
        if(rand.Next(0,2)==0 && mapa[xt+1,yt]==0) mapa[xt+1,yt] =2;
        else mapa[xt-1,yt]=2;

    }
    else{
        //caso não dê para gerar as partetes na vertical irá gerar na HORIZONTAL
        if(rand.Next(0,2)==0 && mapa[xt,yt+1]==0) mapa[xt,yt+1] =2;
        else mapa[xt,yt-1]=2;
    }
}

//GERAR BARCO COM TRES PARTES
if(p==2){
    
    int xt, yt;
    
    
    Gerar3: //íncio do goto que define a posiçãao aleatoria da primeira parte do 3° barco
    //escolher uma posição aleatoria dentro do mapa para a posição da primeira parte do barco
    xt= rand.Next(max-1);
    yt= rand.Next(max-1);
    //CHECAR SE JA NAO TEM BARCO LA, se não tive gera lá
    if (mapa[xt,yt]==0) mapa[xt,yt] = 2;
    //se tiver gera de novo em outo lugar
    else goto Gerar3;

    if( rand.Next(0,2)==0 ){
        //Gera o restante das partes do barco na VERTICAL
        if(mapa[xt+1,yt]==0 && mapa[xt+2,yt]==0) {
            //
            mapa[xt+1,yt]=2;
            mapa[xt+2,yt]=2;
        }
        else if(mapa[xt-1,yt]==0 && mapa[xt-2,yt]==0) {
            mapa[xt-1,yt] =2;
            mapa[xt-2,yt]=2;
        }
        else goto Gerar3;
    }
    else{
        //HORIZONTAL
        if(mapa[xt,yt+1]==0 && mapa[xt,yt+2]==0) {
            mapa[xt,yt+1] =2;
            mapa[xt,yt+2]=2;
        }
        else if(mapa[xt,yt-1]==0 && mapa[xt,yt-2]==0) {
            mapa[xt,yt-1] =2;
            mapa[xt,yt-2]=2;
        }
        else goto Gerar3;
        
    }

}
}

//QUANTAS PARTES DE BARCO TEMOS QUE DESTRUIR PRA GANHAR
if (barcos==1) partes=1;
if (barcos==2) partes=3;
if (barcos==3) partes=6;



do{
    Jogada:
mostrarMapa();

Console.WriteLine("\tJogadas restantes: "+jogadas+ "\n");

//escolha da linha
Console.WriteLine("Escolha uma linha: ");

        try
        {
           x = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("ENTRADA INVÁLIDA!");
            goto Jogada;
        }
        if(x>max || x<=0){
            Console.WriteLine("Não existe essa linha! Escolha entre 1 e "+max+"\n\n");
            //Codigo secreto para obter mais jogadas
            if(x==777) jogadas+=10;
            goto Jogada;
            
        }
x--;


//escolha da coluna
w=-1;

while(w<0){
Console.WriteLine("Escolha uma coluna: ");
        try
        {
            y = Console.ReadLine()[0];
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("ENTRADA INVÁLIDA!");
            goto Jogada;
        }
    if(y=='A' || y=='a') w=0;
    else if(y=='B' || y=='b') w=1;
    else if(y=='C' || y=='c') w=2;
    else if(y=='D' || y=='d') w=3;
    else if(y=='E' || y=='e') w=4;
    else if(y=='F' || y=='f') w=5;
    else if(y=='G' || y=='g') w=6;
    else if(y=='H' || y=='h') w=7;
    else if(y=='I' || y=='i') w=8;
    else if(y=='J' || y=='j') w=9;
    else {
        Console.WriteLine("OPÇÃO INVÁLIDA!\n");
                    goto Jogada;}

    if(w>=max){
        Console.WriteLine("Não existe essa coluna!\n"); 
        w=-1;
        goto Jogada;
    }
}
//checar se ja jogou ai
if(mapa[x,w] ==4 || mapa[x,w] ==3){
    Console.WriteLine("Você já jogou aí!\n");
    goto Jogada;
}
//Jogador acerta o tiro
if(mapa[x,w]==2){
Console.WriteLine("\nAcertou o ataque!!!");
mapa[x,w] = 3;
partes--;
}
//Jogador erra o tiro
else{
Console.WriteLine("\nErrou o ataque!!! :(");
mapa[x,w] = 4;
}
//Descontar a jogada
jogadas--;
//Conferir se o jogador ainda tem jogadas
if(jogadas==0){
    Console.WriteLine("SUAS JOGADAS ACABARAM!!! FIM DE JOGO :<");
    break;
}

}
while(partes>0);

if(partes==0) Console.WriteLine("\n\nPARABÉNS!!! VOCÊ VENCEU! DETONOU TODOS OS BARCOS >:)");

mostrarMapa();

Repetir:
        try
        {
            
            Console.WriteLine("Deseja jogar novamente? \n1-SIM \n2-NÃO");
            op = int.Parse(Console.ReadLine().Trim());
            if (op==1)  goto Menu;
            else  if (op==2)Console.WriteLine("Obrigado por jogar! Tenha um bom dia :>");
            else {
                Console.WriteLine("Opção inválida!");
                goto Repetir;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Opção inválida!");
            goto Repetir;
        }







    }
}