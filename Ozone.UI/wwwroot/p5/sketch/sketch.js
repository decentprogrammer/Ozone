function setup() {
  createCanvas(710, 400, WEBGL);
}

function draw() {
  background(250);

  ambientLight(60, 60, 60);
  pointLight(255, 255, 255, 150, 5, 500);
  
  stroke(0,70,0);
  strokeWeight(.5);
  translate(-240, -100, 0);
  ambientMaterial(0);
  
  translate(240, 0, 0);
  push();
  rotateZ(frameCount * 0.001);
  rotateX(frameCount * 0.000);
  rotateY(frameCount * 0.001);
  fill(0,180,0);
  sphere(30);
  pop();
}
