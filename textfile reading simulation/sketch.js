var fileTextTest;
var text;
var size;
var previousSize;

function setup() {
  createCanvas(400, 400);
  colorMode(HSL);
  frameRate(30);
  strokeWeight(0);
  fill (20, 100, 80);
  textFont("Arial");
  textSize(28);
  textAlign(CENTER,CENTER);
  fileTextTest = "baladais,avenue,coeur,bonjour,";
  text[0]="";
  size=0;
  previousSize = 0;
  n=0;
}

function draw() {
  background(55,100,90);
  //load text file
  if(size<fileTextTest.length){
    updateText();
  }
  writeText();
}

function updateText(){
  size = fileTextTest.length;
  for(i=previousSize; i<size; i++){
    if(fileTextTest.charAt(i) != ","){
      text[n]+=fileTextTest.charAt(i);
    }else{
      n++;
      text[n]="";
    }
  }
  previousSize = fileTextTest.length;
}

//quite crappy but it doesn't really matter in that program
function writeText(){
    text(text[0], 50, 50);
    text(text[1], 50, 70);
    text(text[2], 100, 100);
    text(text[3], 150, 150);
    text(text[4], 200, 200);
    text(text[5], 220, 220);
    text(text[6], 250, 250);
}

//in order to simulate words added to the text file
function mousePressed(){
  fileTextTest+="test,test2,zut,";
}
