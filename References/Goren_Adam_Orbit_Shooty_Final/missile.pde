ArrayList<Missile> missiles = new ArrayList<Missile>();

class Missile{
  int missileSize=10;
  PVector position, velocity;
  Missile(PVector position, PVector velocity){
    this.position = position;
    this.velocity = velocity;
  }

void draw(){
  fill(255,12,200); //Pink
  ellipse(this.position.x,this.position.y,missileSize,missileSize);
  this.position.add(this.velocity);
  if(this.position.y+missileSize>height){ //Missile leaves the area.
    missiles.remove(this);
    }
    if(dist(this.position.x,this.position.y,shipPosition.x,shipPosition.y) < 37.5+5 && sunLife>0){ //Missile x Player
      missiles.remove(this);
      gameover=true;
    }
  }
}

ArrayList<Rocket> rockets = new ArrayList<Rocket>();

class Rocket{
  int rocketSize=20;
  PVector position, velocity;
  Rocket(PVector position, PVector velocity){
    this.position = position;
    this.velocity = velocity;
  }

void draw(){
  fill(255,12,200); //Pink
  ellipse(this.position.x,this.position.y,rocketSize,rocketSize);
  this.position.add(this.velocity);
  if((this.position.y+rocketSize>height) || (this.position.y-rocketSize<0) 
  || (this.position.x+rocketSize>width) || (this.position.x-rocketSize<0)){ //Rockets leave the area.
    rockets.remove(this);
    }
    if(dist(this.position.x,this.position.y,shipPosition.x,shipPosition.y) < 37.5+10 && !win){ //Rockets x Player
      rockets.remove(this);
      gameover=true;
    }
  }
}

void drawMissiles(){
  for (int i = 0; i < missiles.size(); i++) {
    Missile missile = missiles.get(i);
    missile.draw();
  }
}

void drawRockets(){
  for (int i = 0; i < rockets.size(); i++) {
    Rocket rocket = rockets.get(i);
    rocket.draw();
  }
}
