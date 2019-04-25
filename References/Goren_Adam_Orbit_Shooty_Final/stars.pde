ArrayList<Star> stars = new ArrayList<Star>();
ArrayList<Star> starsMed = new ArrayList<Star>();
ArrayList<Star> starsBig = new ArrayList<Star>();

int drawCounter=0;
int drawCounter2=0;
int drawCounter3=0;

void starGen(){
  if(drawCounter>=2){
  spawnStar();
  drawCounter=0;
  }
  if(drawCounter2>=3){
    spawnStarMed();
    drawCounter2=0;
  }
  if(drawCounter3>=4){
    spawnStarBig();
    drawCounter3=0;
  }
  
  despawnStar();
  drawStars();
  
  drawCounter++;
  drawCounter2++;
  drawCounter3++;
}

class Star{
  int diameter = 2;
  int diameter2 = 3;
  int diameter3 = 4;
  
  PVector position = new PVector(100,100);
  
  PVector speed = new PVector(0,5);
  PVector speed2 = new PVector(0,10);
  PVector speed3 = new PVector(0,15);
  
  void drawStar(){
    noStroke();
    fill(255);
    ellipse(position.x,position.y,diameter,diameter);
    
    position.add(speed);
  }
  
  void drawStarMed()
  {
    ellipse(position.x,position.y,diameter2,diameter2);
    position.add(speed2);
  }

  void drawStarBig()
  {
    ellipse(position.x,position.y,diameter3,diameter3);
    position.add(speed3);
  }
}


void drawStars(){
  for(int i=0;i<stars.size();i++){
    stars.get(i).drawStar();
  }
  for(int i=0;i<starsMed.size();i++){
    starsMed.get(i).drawStarMed();
  }
  for(int i=0;i<starsBig.size();i++){
    starsBig.get(i).drawStarBig();
  }
}

void initialStar(){
    for (int i=0;i<80;i++){ //Small Stars
    Star spawn = new Star();
    spawn.position = new PVector(random(0,width), random(0,height));
    
    stars.add(spawn);
    }
    
    for (int i=0;i<25;i++){ //Medium Stars
    Star spawn = new Star();
    spawn.position = new PVector(random(0,width), random(0,height));
    
    starsMed.add(spawn);
    }
    
    for (int i=0;i<15;i++){ //Big Stars
    Star spawn = new Star();
    spawn.position = new PVector(random(0,width), random(0,height));
    
    starsBig.add(spawn);
    }
  }

void spawnStar(){
  
    Star spawn = new Star();
    spawn.position = new PVector(random(0,width), 0);
    
    stars.add(spawn);
}

void spawnStarMed(){
    
    Star spawn = new Star();
    spawn.position = new PVector(random(0,width), 0);
    
    starsMed.add(spawn);
}

void spawnStarBig(){
    
    Star spawn = new Star();
    spawn.position = new PVector(random(0,width), 0);
    
    starsBig.add(spawn);
}

void despawnStar(){
    for (int i=stars.size()-1; i>=0; i--) 
    {
      Star spawn = stars.get(i);
      if(spawn.position.y >= height)
      {
        stars.remove(spawn);
      }
    }
    for (int i=starsMed.size()-1; i>=0; i--) 
    {
      Star spawn = starsMed.get(i);
      if(spawn.position.y >= height)
      {
        starsMed.remove(spawn);
      }
    }
    for (int i=starsBig.size()-1; i>=0; i--) 
    {
      Star spawn = starsBig.get(i);
      if(spawn.position.y >= height)
      {
        starsBig.remove(spawn);
      }
    }
}
