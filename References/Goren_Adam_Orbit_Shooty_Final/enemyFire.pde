int [] missileTimer = new int [6];

void enemyFire(){
  //Shooting Patterns
  if(!gameover){
    if(!stage[0] && posY[0]>centerY){ //First planet.
      if(missileTimer[0]>=150){
      PVector newMissilePos = new PVector(posX[0],posY[0]);
      
      PVector missileVelocity = new PVector(0,2);
      
      Missile newMissile = new Missile(newMissilePos, missileVelocity);
      missiles.add(newMissile);
      
      missileTimer[0]=0;
      }
    }
    if(stage[0] && !stage[1] && posY[1]>centerY){ //Second planet.
      if(missileTimer[1]>=125){
      PVector newMissilePos = new PVector(posX[1],posY[1]);
      
      PVector missileVelocity = new PVector(0,4);
      
      Missile newMissile = new Missile(newMissilePos, missileVelocity);
      missiles.add(newMissile);
      
      missileTimer[1]=0;
      }
    }
    if(stage[1] && !stage[2] && posY[2]>centerY){ //Third planet.
      if(missileTimer[2]>=100){
      PVector newMissilePos1 = new PVector(posX[2],posY[2]);
      PVector newMissilePos2 = new PVector(posX[2],posY[2]);
      PVector newMissilePos3 = new PVector(posX[2],posY[2]);
      
      PVector missileVelocity1 = new PVector(0,4);
      PVector missileVelocity2 = new PVector(-3,4);
      PVector missileVelocity3 = new PVector(3,4);
      
      Missile newMissile1 = new Missile(newMissilePos1, missileVelocity1);
      Missile newMissile2 = new Missile(newMissilePos2, missileVelocity2);
      Missile newMissile3 = new Missile(newMissilePos3, missileVelocity3);
      
      missiles.add(newMissile1);
      missiles.add(newMissile2);
      missiles.add(newMissile3);
      
      missileTimer[2]=0;
      }
    }
    if(stage[2] && !stage[3] && posY[3]>centerY){ //Fourth planet.
      if(missileTimer[3]>=75){
      PVector newMissilePos1 = new PVector(posX[3],posY[3]);
      PVector newMissilePos2 = new PVector(posX[3],posY[3]);
      PVector newMissilePos3 = new PVector(posX[3],posY[3]);
      
      PVector missileVelocity1 = new PVector(0,5);
      PVector missileVelocity2 = new PVector(-3,5);
      PVector missileVelocity3 = new PVector(3,5);
      
      Missile newMissile1 = new Missile(newMissilePos1, missileVelocity1);
      Missile newMissile2 = new Missile(newMissilePos2, missileVelocity2);
      Missile newMissile3 = new Missile(newMissilePos3, missileVelocity3);
      
      missiles.add(newMissile1);
      missiles.add(newMissile2);
      missiles.add(newMissile3);
      
      missileTimer[3]=0;
      }
    }
    if(stage[3] && !stage[4] && posY[4]>centerY){ //Fifth planet.
      if(missileTimer[4]>=50){
      PVector newMissilePos1 = new PVector(posX[4],posY[4]);
      PVector newMissilePos2 = new PVector(posX[4],posY[4]);
      PVector newMissilePos3 = new PVector(posX[4],posY[4]);
      PVector newMissilePos4 = new PVector(posX[4],posY[4]);
      PVector newMissilePos5 = new PVector(posX[4],posY[4]);
      
      PVector missileVelocity1 = new PVector(0,5);
      PVector missileVelocity2 = new PVector(-3,5);
      PVector missileVelocity3 = new PVector(3,5);
      PVector missileVelocity4 = new PVector(-6,5);
      PVector missileVelocity5 = new PVector(6,5);
      
      Missile newMissile1 = new Missile(newMissilePos1, missileVelocity1);
      Missile newMissile2 = new Missile(newMissilePos2, missileVelocity2);
      Missile newMissile3 = new Missile(newMissilePos3, missileVelocity3);
      Missile newMissile4 = new Missile(newMissilePos4, missileVelocity4);
      Missile newMissile5 = new Missile(newMissilePos5, missileVelocity5);
      
      missiles.add(newMissile1);
      missiles.add(newMissile2);
      missiles.add(newMissile3);
      missiles.add(newMissile4);
      missiles.add(newMissile5);
      
      missileTimer[4]=0;
      }
    }
    if(stage[4] && sunLife>0){ //Sun
      if(missileTimer[5]>=100){
      PVector newMissilePos1 = new PVector(centerX,centerY);
      PVector newMissilePos2 = new PVector(centerX,centerY);
      PVector newMissilePos3 = new PVector(centerX,centerY);
      PVector newMissilePos4 = new PVector(centerX,centerY);
      PVector newMissilePos5 = new PVector(centerX,centerY);
      PVector newMissilePos6 = new PVector(centerX,centerY);
      PVector newMissilePos7 = new PVector(centerX,centerY);
      PVector newMissilePos8 = new PVector(centerX,centerY);
      
      PVector missileVelocity1 = new PVector(0,5);
      PVector missileVelocity2 = new PVector(-5,5);
      PVector missileVelocity3 = new PVector(5,5);
      PVector missileVelocity4 = new PVector(-5,0);
      PVector missileVelocity5 = new PVector(5,0);
      PVector missileVelocity6 = new PVector(5,-5);
      PVector missileVelocity7 = new PVector(-5,-5);
      PVector missileVelocity8 = new PVector(0,-5);
      
      Rocket newMissile1 = new Rocket(newMissilePos1, missileVelocity1);
      Rocket newMissile2 = new Rocket(newMissilePos2, missileVelocity2);
      Rocket newMissile3 = new Rocket(newMissilePos3, missileVelocity3);
      Rocket newMissile4 = new Rocket(newMissilePos4, missileVelocity4);
      Rocket newMissile5 = new Rocket(newMissilePos5, missileVelocity5);
      Rocket newMissile6 = new Rocket(newMissilePos6, missileVelocity6);
      Rocket newMissile7 = new Rocket(newMissilePos7, missileVelocity7);
      Rocket newMissile8 = new Rocket(newMissilePos8, missileVelocity8);
      
      rockets.add(newMissile1);
      rockets.add(newMissile2);
      rockets.add(newMissile3);
      rockets.add(newMissile4);
      rockets.add(newMissile5);
      rockets.add(newMissile6);
      rockets.add(newMissile7);
      rockets.add(newMissile8);
      
      missileTimer[5]=0;
      }
    }
  }
  for(int i=0;i<6;i++){
  missileTimer[i]++;
  }
}
