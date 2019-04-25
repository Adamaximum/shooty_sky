ArrayList<Bullet> bullets = new ArrayList<Bullet>();

class Bullet{
  int bulletSize=10;
  PVector position, velocity;
  Bullet(PVector position, PVector velocity){
    this.position = position;
    this.velocity = velocity;
  }

void draw(){
  fill(0,255,0); //Green
  ellipse(this.position.x,this.position.y,bulletSize,bulletSize);
  this.position.add(this.velocity);
  if(this.position.y+bulletSize<0){ //Bullet leaves the area.
    bullets.remove(this);
    }
    if(dist(this.position.x,this.position.y,centerX,centerY) < pulse/2+5){ //Bullet x Sun
      bullets.remove(this);
      sunLife-=5;
    }
    for(int e=0;e<missiles.size();e++){
      if(dist(this.position.x,this.position.y,missiles.get(e).position.x,missiles.get(e).position.y) < 5+5){ //Bullet x Missile
        bullets.remove(this);
        missiles.remove(missiles.get(e));
      }
    }
    for(int e=0;e<rockets.size();e++){
      if(dist(this.position.x,this.position.y,rockets.get(e).position.x,rockets.get(e).position.y) < 10+5){ //Bullet x Rocket
        bullets.remove(this);
        rockets.remove(rockets.get(e));
      }
    }
  }
}

void drawBullets(){
  for (int i = 0; i < bullets.size(); i++) {
    Bullet bullet = bullets.get(i);
    bullet.draw();
  }
}
