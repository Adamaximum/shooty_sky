boolean up;
boolean left;
boolean down;
boolean right;

void movement(){
  if (up && shipPosition.y-shipH/2>0) {
    shipPosition.y-=5;
  }
  if (left && shipPosition.x-shipW/2>0) {
    shipPosition.x-=5; 
  }
  if (down && shipPosition.y+shipH/2<height) {
    shipPosition.y+=5; 
  }
  if (right && shipPosition.x+shipW/2<width) {
    shipPosition.x+=5; 
  }
}

void move(){
 if (keyCode == UP) {
  up = true; 
 }
 if (keyCode == LEFT) {
  left = true; 
 }
 if (keyCode == DOWN) {
  down = true; 
 }
 if (keyCode == RIGHT) {
  right = true; 
 }  
}

void moveStop(){
   if (keyCode == UP) {
    up = false; 
   }
   if (keyCode == LEFT) {
    left = false; 
   }
   if (keyCode == DOWN) {
    down = false; 
   }
   if (keyCode == RIGHT) {
    right = false; 
  }
}
