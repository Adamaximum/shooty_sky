Minim masterAudio;
AudioPlayer bass1;
AudioPlayer bass2;
AudioPlayer backing;
AudioPlayer perc;
AudioPlayer melody;
AudioPlayer winMelody;

AudioPlayer silence;

AudioPlayer shooterFire;

void gen(){
  initialStar();
  
  ship=loadImage("pixel-spaceship.png");
  
  orbit = createFont("earthorbiterpunch.ttf",100);
  
  masterAudio = new Minim(this);
  bass1 = masterAudio.loadFile("big rip.2.mp3");
  bass2 = masterAudio.loadFile("crackle bass.2.mp3");
  backing = masterAudio.loadFile("Bouncing MS-20.2.mp3");
  perc = masterAudio.loadFile("Stylus Loop.2.mp3");
  melody = masterAudio.loadFile("radiotone melodies.2.mp3");
  winMelody = masterAudio.loadFile("early warmies.2.mp3");
  
  silence = masterAudio.loadFile("0917.mp3");
  
  bass1.loop();
  bass2.loop();
  backing.loop();
  perc.loop();
  melody.loop();
  winMelody.loop();
  silence.loop();
  
  shooterFire = masterAudio.loadFile("shooter_fire.wav");
}

void vals(){
  //Player Initial Values
  shipPosition.x=width/2;
  shipPosition.y=height-100;
  
  playerAlpha=255;
  
  //Enemy Stage
  for(int i=0;i<5;i++){
  stage[i]=false;
  }
  
  //Sun Attributes
  entrance=true;
  sunLife=255;
  sun = color(255,sunLife,0);
  pulse = 150;
  
  centerX=width+350;
  centerY=220;
  
  enemyMoveX=2;
  enemyMoveY=2;
  
  //Planetary Orbit
  for(int i=0;i<5;i++){
    randCos[i]=int(random(2));
    randSin[i]=int(random(2));
    
    if(randCos[i]==0){
      resCos[i]=1;
    }
    else{
      resCos[i]=-1;
    }
    
    if(randSin[i]==0){
      resSin[i]=1;
    }
    else{
      resSin[i]=-1;
    }
    
    planets[i]=color(random(0,255),random(0,255),random(0,255));
    
    alpha[i]=255;
    
  }
  
  alpha[5]=255;
  
  orbitLine[0]=400;
  orbitLine[1]=350;
  orbitLine[2]=300;
  orbitLine[3]=250;
  orbitLine[4]=200;
  
  //Planet Orbit Radii
  radius[0]=200;
  radius[1]=175;
  radius[2]=150;
  radius[3]=125;
  radius[4]=100;
  
  //Start Menu (Targets)
  //textY[0]=140;
  //textY[1]=225;
  
  //buttonX[0]=90;
  //buttonX[1]=362;
  //buttonX[2]=784;
  
  //for(int i=0; i<3; i++){
  //  buttonY[i]=514;
  //  buttonH[i]=50;
  //}
  
  //buttonW[0]=150;
  //buttonW[1]=300;
  //buttonW[2]=150;
  
  //Start Menu
  textY[0]=-100;
  textY[1]=height+100;
  
  buttonX[0]=-250;
  buttonX[1]=362;
  buttonX[2]=width+100;
  
  buttonY[0]=514;
  buttonY[1]=height+100;
  buttonY[2]=514;
  
  for(int i=0; i<3; i++){
    buttonH[i]=50;
  }
  
  buttonW[0]=150;
  buttonW[1]=300;
  buttonW[2]=150;
  
  //Controls Menu
  buttonX[3]=90;
  buttonY[3]=575;
  buttonW[3]=150;
  buttonH[3]=50;
  
  //End Buttons
  buttonX[4]=-250;
  buttonY[4]=514;
  buttonW[4]=250;
  buttonH[4]=50;
  
  buttonX[5]=width+100;
  buttonY[5]=514;
  buttonW[5]=150;
  buttonH[5]=50;
  
  //All Buttons
  for(int i=0; i<4; i++){
    hover[i]=color(0,0,255);
  }
}
