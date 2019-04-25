float [] textY = new float[4];

float [] buttonX = new float[6];
float [] buttonY = new float[6];

float [] buttonW = new float[6];
float [] buttonH = new float[6];

color [] hover = new color[6];

void begin(){ //Start Menu
  textFont(orbit);
  textAlign(CENTER);
  text("Orbit Shooty",width/2,textY[0]);
  textSize(50);
  text("by Adam Goren",width/2,textY[1]);
  
  noFill();
  
  for(int i=0;i<3;i++){
    stroke(hover[i]);
    rect(buttonX[i],buttonY[i],buttonW[i],buttonH[i]);
    
    if(mouseX>buttonX[i] && mouseX<buttonX[i]+buttonW[i] && mouseY>buttonY[i] && mouseY<buttonY[i]+buttonH[i]){
      hover[i]=color(0,255,0);
    }
    else{
      hover[i]=color(0,0,255);
    }
  }
  
  //Reference Rects
  //rectMode(CENTER);
  //rect(165,540,150,50);
  //rect(512,540,300,50);
  //rect(859,540,150,50);
  
  //rect(90,514,150,50);
  //rect(362,514,300,50);
  //rect(784,514,150,50);
  
  text("Play",buttonX[0]+75,buttonY[0]+41);
  text("Controls",buttonX[1]+150,buttonY[1]+41);
  text("Quit",buttonX[2]+75,buttonY[2]+41);
  
  if(textY[0]<140){
    textY[0]+=5;
  }
  if(textY[1]>225){
    textY[1]-=5;
  }
  if(textY[0]>=140 && textY[1]<=225){
    if(buttonX[0]<90){
      buttonX[0]+=5;
    }
    if(buttonY[1]>514){
      buttonY[1]-=5;
    }
    if(buttonX[2]>784){
      buttonX[2]-=5;
    }
  }
  
  if(mousePressed){
    if(mouseX>buttonX[0] && mouseX<buttonX[0]+buttonW[0] && mouseY>buttonY[0] && mouseY<buttonY[0]+buttonH[0]){
        start=false;
        game=true;
      }
    else if(mouseX>buttonX[1] && mouseX<buttonX[1]+buttonW[1] && mouseY>buttonY[1] && mouseY<buttonY[1]+buttonH[1]){
        start=false;
        inst=true;
      }
    else if(mouseX>buttonX[2] && mouseX<buttonX[2]+buttonW[2] && mouseY>buttonY[2] && mouseY<buttonY[2]+buttonH[2]){
        exit();
      }
  }
}

void controls(){ //Controls menu
  text("Use the arrow keys to move.",width/2,100);
  text("Press Space to shoot.",width/2,200);
  //text("Press M to mute.",width/2,400);
  text("Press ESC to quit.",width/2,500);
  
  noFill();
  stroke(hover[3]);
  rect(buttonX[3],buttonY[3],buttonW[3],buttonH[3]);
    
  if(mouseX>buttonX[3] && mouseX<buttonX[3]+buttonW[3] && mouseY>buttonY[3] && mouseY<buttonY[3]+buttonH[3]){
    hover[3]=color(0,255,0);
  }
  else{
    hover[3]=color(0,0,255);
  }
  
  text("Back",buttonX[3]+75,buttonY[3]+41);
  
  if(mousePressed){
    if(mouseX>buttonX[3] && mouseX<buttonX[3]+buttonW[3] && mouseY>buttonY[3] && mouseY<buttonY[3]+buttonH[3]){
      inst=false;
      start=true;
    }
  }
}

int playerAlpha;
int textFlash;

void endScreen(){ //End menu
  fill(255);
  textSize(100);
  
  //Game Over or You Win Text
  if(gameover){
    playerAlpha=0;
    text("Game Over!",width/2,textY[2]);
  }
  else if(win){
    text("You Win!",width/2,textY[3]);
  }
  
  //Flashing "Play Again?"
  if(textFlash>=20){
    fill(255,0);
  }
  if(textFlash>=60){
  textFlash=0;
}
  else if(textFlash<=20){
    fill(255,255);
  }
  textFlash++;
  
  textSize(50);
  text("Play Again?",width/2,225);
  
  if(textY[2]<140){
    textY[2]+=5;
  }
  if(textY[3]<140){
    textY[3]+=5;
  }
  if(textY[2]>=140 || textY[3]>=140){
    if(buttonX[4]<90){
      buttonX[4]+=5;
    }
    if(buttonX[5]>784){
      buttonX[5]-=5;
    }
  }
  
  fill(255,255);
  text("Restart",buttonX[4]+125,buttonY[4]+41);
  text("Quit",buttonX[5]+75,buttonY[5]+41);
  
  noFill();
  
  for(int i=4;i<6;i++){
    stroke(hover[i]);
    rect(buttonX[i],buttonY[i],buttonW[i],buttonH[i]);
    
    if(mouseX>buttonX[i] && mouseX<buttonX[i]+buttonW[i] && mouseY>buttonY[i] && mouseY<buttonY[i]+buttonH[i]){
      hover[i]=color(0,255,0);
    }
    else{
      hover[i]=color(0,0,255);
    }
  }
  
  if(mousePressed){
    if(mouseX>buttonX[4] && mouseX<buttonX[4]+buttonW[4] && mouseY>buttonY[4] && mouseY<buttonY[4]+buttonH[4]){
      vals();  
      start=true;
      game=false;
      gameover=false;
      win=false;
      }
    else if(mouseX>buttonX[5] && mouseX<buttonX[5]+buttonW[5] && mouseY>buttonY[5] && mouseY<buttonY[5]+buttonH[5]){
        exit();
      }
  }
  
}
