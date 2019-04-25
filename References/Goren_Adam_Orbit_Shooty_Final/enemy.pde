boolean [] stage = new boolean [5];
boolean entrance;

color sun;
int sunLife;

color [] planets = new color [5];

int [] alpha = new int [6];

int centerX;
int centerY;

int enemyMoveX;
int enemyMoveY;

int [] orbitLine = new int [5];

float pulse;
float change;

int [] randCos = new int [5];
int [] randSin = new int [5];

int [] resCos = new int [5];
int [] resSin = new int [5];

float [] posX = new float [5];
float [] posY = new float [5];

float [] radius = new float [5];

float [] theta = new float [5];

void enemy(){
  
  //Sun
  if(stage[4] && sunLife>0){
    centerX+=enemyMoveX;
    centerY+=enemyMoveY;
    
    if(centerX-pulse/2<=0){
      enemyMoveX*=-1;
    }
    if(centerX+pulse/2>=width){
      enemyMoveX*=-1;
    }
    if(centerY-pulse/2<=0){
      enemyMoveY*=-1;
    }
    if(centerY+pulse/2>=height){
      enemyMoveY*=-1;
    }
  }
  else if(!stage[4]){
    if(centerX<width/2 && entrance){
      entrance=false;
    }
    if(entrance){
      centerX-=enemyMoveX;
    }
    else{
      centerX-=enemyMoveX;
      if(centerX-100<=0 || centerX+100>=width){
        enemyMoveX*=-1;
      }
    }
  }
  
  sun=color(255,sunLife,0,alpha[5]);
  fill(sun);
  ellipse(centerX,centerY,pulse,pulse);
  
  pulse+=change;
  
  if(pulse>=150){
    change=-0.4;
  }
  else if(pulse<=125){
    change=0.4;
  }
  
  //Orbit Rings
  noFill();
  for(int i=0;i<5;i++){
    //println("Stage "+i+": "+stage[i]);
   stroke(255,alpha[i]);
    if(stage[i]==true){
      alpha[i]=0;
    }
    else{
      alpha[i]=255;
    }
   ellipse(centerX,centerY,orbitLine[i],orbitLine[i]);
    if(!stage[i]){
      if(dist(shipPosition.x,shipPosition.y,centerX,centerY) < orbitLine[i]/2+37.5){ //Player x Orbit
    gameover=true;
      }
    }
     for(int e=0;e<bullets.size();e++){ //Bullet x Orbit
      if(!stage[i]){
        if(dist(bullets.get(e).position.x,bullets.get(e).position.y,centerX,centerY) < orbitLine[i]/2+5){
    bullets.remove(bullets.get(e));
          }
        }
      }
     }
  
  //Planets
  for(int i=0;i<5;i++){ //Planet Generation
    fill(planets[i],alpha[i]);
    noStroke();
    ellipse(posX[i],posY[i],20,20);
    
    posX[i]=centerX+(radius[i]*resCos[i]*cos(theta[i]));
    posY[i]=centerY+(radius[i]*resSin[i]*sin(theta[i]));
    
    //println(randCos[i],randSin[i]);
    //println(resCos[i],resSin[i]);
    
    for(int e=0;e<bullets.size();e++){ //Bullet x Planet
      if(!stage[i]){
        if(dist(bullets.get(e).position.x,bullets.get(e).position.y,posX[i],posY[i]) < 10+5){
          bullets.remove(bullets.get(e));
          alpha[i]=0;
          stage[i]=true;
         }
       }
     }
    if(!stage[i]){
      if(dist(shipPosition.x,shipPosition.y,posX[i],posY[i]) < 10+37.5){ //Player x Planet
        gameover=true;
       }
     }
   }
  
  theta[0]+=0.01;
  theta[1]-=0.02;
  theta[2]+=0.03;
  theta[3]-=0.04;
  theta[4]+=0.05;
  
  enemyFire(); //Enemy shooting function.
  
  if(sunLife<0){
    alpha[5]=0;
    win=true;
  }
}
