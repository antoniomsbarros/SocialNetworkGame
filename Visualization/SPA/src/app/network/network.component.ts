import {AfterViewInit, Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import * as THREE from "three";
import {OrbitControls} from 'three/examples/jsm/controls/OrbitControls';


@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.css']
})
export class NetworkComponent implements OnInit, AfterViewInit {

  @ViewChild('networkRef')
  private networkRef!: ElementRef;

  private get networkElement(): HTMLCanvasElement {
    return this.networkRef.nativeElement;
  }

  constructor() {
  }


  ngOnInit(): void {


  }


  ngAfterViewInit() {
    this.initializeGraph();
    this.animate();
  }

  scene!: THREE.Scene;
  renderer!: THREE.WebGLRenderer;
  camera!: THREE.PerspectiveCamera;
  controls!: OrbitControls;

  initializeGraph() {
    this.scene = new THREE.Scene();
    this.scene.background = new THREE.Color(0xc9aa88);

    this.renderer = new THREE.WebGLRenderer();
    this.networkElement.appendChild(this.renderer.domElement);
    this.renderer.setSize(window.innerWidth, window.innerHeight);

    this.camera = new THREE.PerspectiveCamera(45, window.innerWidth / window.innerHeight, 1, 10000);

    const geometry = new THREE.CircleGeometry(4, 32);

    let material = new THREE.MeshBasicMaterial({ color: 0x4B756C });
    let circle = new THREE.Mesh(geometry, material);
    this.scene.add(circle);


    material = new THREE.MeshBasicMaterial({ color: 0x841A00 });
    circle = new THREE.Mesh(geometry, material);
    circle.position.x = 20;
    circle.position.y = 30;
    this.scene.add(circle);





    this.controls = new OrbitControls(this.camera, this.renderer.domElement);
    this.controls.enableZoom = true;
    this.controls.enablePan = true;
    this.controls.enableRotate = false;

    this.camera.position.set(0, 20, 100);
    this.controls.update();

    window.addEventListener( 'resize', this.onWindowResize, false );
  }

  onWindowResize(){
    this.camera.aspect = window.innerWidth / window.innerHeight;
    this.camera.updateProjectionMatrix();
    this.renderer.setSize( window.innerWidth, window.innerHeight );

  }

  animate() {
    requestAnimationFrame(this.animate.bind(this));
    this.controls.update();
    this.renderer.render(this.scene, this.camera);
  }
}
