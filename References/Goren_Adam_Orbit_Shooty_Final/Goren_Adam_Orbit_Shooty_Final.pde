//Orbit Shooty
//by Adam Goren
//My most difficult and enduring task in Processing yet. Enjoy!

import ddf.minim.*;
import ddf.minim.analysis.*;
import ddf.minim.effects.*;
import ddf.minim.signals.*;
import ddf.minim.spi.*;
import ddf.minim.ugens.*;

PVector shipPosition = new PVector(width/2,height/2);

int shipW = 75;
int shipH = 75;

PImage ship;

int bulletLimit;

PFont orbit;

boolean start = true;
boolean game = false;
boolean inst = false;
boolean gameover = false;
boolean win = false;

void setup(){
  size(1024,768);
  
  gen(); //Elements that are generated once.
  vals(); //Elements that are regenerated when the program restarts.
  
}

void draw(){
  background(0);
  fill(255);

  audio(); //Audio Settings.
  
  starGen(); //Star Generation.
  
  //Gamestates
  if(start){
  begin();
  }
  else if(inst){
    controls();
  }
  else if(game){
  if(!gameover){
    movement();
  }
  enemy();
  drawMissiles();
  if(stage[4]){
  drawRockets();
  }
  
  drawBullets();
  bulletLimit++;
  
  imageMode(CENTER);
  tint(255,playerAlpha);
  image(ship,shipPosition.x,shipPosition.y,shipW,shipH);
  
  }
  
  if(gameover || win){
    endScreen();
  }
  //println("UP: "+up);
  //println("LEFT: "+left);
  //println("DOWN: "+down);
  //println("RIGHT: "+right);
  
  //println("Small Stars: "+stars.size());
  //println("Med Stars: "+starsMed.size());
  //println("Big Stars: "+starsBig.size());
  
  //println(mouseX,mouseY);
  
}

void keyPressed(){
  move(); //Movement functions.
  
  //Player Shooting
  if(key== ' ' && bulletLimit>=10 && !gameover){
    PVector newBulletPos = new PVector(shipPosition.x,shipPosition.y);
    
    PVector bulletVelocity = new PVector(0,-7);
    
    Bullet newBullet = new Bullet(newBulletPos, bulletVelocity);
    bullets.add(newBullet);
    
    bulletLimit=0;
    
    shooterFire.play(); //Only plays once for some reason. Future fix.
  }
  
  //Muting (currently not functional)
  //if(key=='m' || key=='M'){
  //  if(!muteControl){
  //    muteControl=true;
  //  }
  //  else if(muteControl){
  //    muteControl=false;
  //  }
  //}
  
  //Quitting the game
  if (keyCode==ESC){
    exit();
  }
}

void keyReleased(){
  moveStop();
}
