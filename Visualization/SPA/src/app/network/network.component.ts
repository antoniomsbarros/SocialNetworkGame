import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {RelactionShipServiceService} from "../services/relaction-ship-service.service";
import {NetworkFromPlayerPerspectiveDto} from '../dto/relationships/NetworkFromPlayerPerspectiveDto';
import * as THREE from "three";
import {OrbitControls} from 'three/examples/jsm/controls/OrbitControls';
import {TextGeometry} from 'three/examples/jsm/geometries/TextGeometry';
import {FontLoader} from 'three/examples/jsm/loaders/FontLoader';
import {Location} from "@angular/common";
import {Sphere, Vector4} from "three";
import {CSS2DObject, CSS2DRenderer} from "three/examples/jsm/renderers/CSS2DRenderer";
import { FlyControls } from 'three/examples/jsm/controls/FlyControls.js';
import {PointerLockControls} from "three/examples/jsm/controls/PointerLockControls";
import Stats from "three/examples/jsm/libs/stats.module";
import {NodeLib} from "three/examples/jsm/nodes/core/NodeLib";
import nodes = NodeLib.nodes;

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.css']
})
export class NetworkComponent implements OnInit {
  @ViewChild('networkRef')
  private networkRef!: ElementRef;

  private get networkElement(): HTMLCanvasElement {
    return this.networkRef.nativeElement;
  }

   mouse=new THREE.Vector2();

  get networkDepth(): any {
    return this.getNetworkAtDepth.get('networkDepth');
  }


  constructor(public relationshipService: RelactionShipServiceService, private location: Location) {
  }

  ngOnInit(): void {
  }

  showDepthSelectionForm: boolean = true;
  showNetworkGraph: boolean = false;

  minDepth: number = 1;
  getNetworkAtDepth = new FormGroup({
    networkDepth: new FormControl('', [Validators.required, Validators.min(this.minDepth)]),
  });


  getTestNetwork(depth: number) {
    switch (depth) {
      case 1:
        this.network = JSON.parse('{"playerId":"05d54773-07b4-4483-8653-0b2dbe112521","playerName":"Loy Seamus","playerTags":[],"relationships":[{"relationshipId":"0998e0ef-79e8-4195-a2ad-c35335e1124f","relationshipStrength":8,"relationshipTags":["t10"],"playerId":"1ae293fa-3e50-41e6-b87e-83ef4c36aac7","playerName":"Thaddeus Nico","playerTags":[],"relationships":[]},{"relationshipId":"b0ec7397-352e-4bb5-a93c-0a59d985aab0","relationshipStrength":4,"relationshipTags":["t4"],"playerId":"e3aa14d3-c662-4e76-ba3b-3e1c40c3957c","playerName":"Magdalena Garnett","playerTags":[],"relationships":[]}]}');
        break;
      case 2:
        this.network = JSON.parse('{"playerId":"05d54773-07b4-4483-8653-0b2dbe112521","playerName":"Loy Seamus","playerTags":[],"relationships":[{"relationshipId":"0998e0ef-79e8-4195-a2ad-c35335e1124f","relationshipStrength":8,"relationshipTags":["t10"],"playerId":"1ae293fa-3e50-41e6-b87e-83ef4c36aac7","playerName":"Thaddeus Nico","playerTags":[],"relationships":[{"relationshipId":"cd2283f5-fc03-4aa9-952a-34748f5106bf","playerId":"8451f82d-943d-4338-a80e-3a2e73890358","playerName":"Harvey Alaina","relationships":[]}]},{"relationshipId":"b0ec7397-352e-4bb5-a93c-0a59d985aab0","relationshipStrength":4,"relationshipTags":["t4"],"playerId":"e3aa14d3-c662-4e76-ba3b-3e1c40c3957c","playerName":"Magdalena Garnett","playerTags":[],"relationships":[{"relationshipId":"44a71855-9c28-4756-a776-8466f40d39a9","playerId":"8451f82d-943d-4338-a80e-3a2e73890358","playerName":"Harvey Alaina","relationships":[]}]}]}');
        break;
      case 3:
        this.network = JSON.parse('{"playerId":"05d54773-07b4-4483-8653-0b2dbe112521","playerName":"Loy Seamus","playerTags":[],"relationships":[{"relationshipId":"0998e0ef-79e8-4195-a2ad-c35335e1124f","relationshipStrength":8,"relationshipTags":["t10"],"playerId":"1ae293fa-3e50-41e6-b87e-83ef4c36aac7","playerName":"Thaddeus Nico","playerTags":[],"relationships":[{"relationshipId":"cd2283f5-fc03-4aa9-952a-34748f5106bf","playerId":"8451f82d-943d-4338-a80e-3a2e73890358","playerName":"Harvey Alaina","relationships":[{"relationshipId":"032f6925-301c-4121-a59e-e3302549e174","playerId":"aa58b458-65c7-4941-b32a-62b06c24280d","playerName":"Courtney Ulises","relationships":[]},{"relationshipId":"830cb59d-c7fd-4d33-8db7-16597b178c00","playerId":"e3aa14d3-c662-4e76-ba3b-3e1c40c3957c","playerName":"Magdalena Garnett","relationships":[]},{"relationshipId":"cdbc217c-f363-4b7c-ad96-e594e4cb77f8","playerId":"1ae293fa-3e50-41e6-b87e-83ef4c36aac7","playerName":"Thaddeus Nico","relationships":[]}]}]},{"relationshipId":"b0ec7397-352e-4bb5-a93c-0a59d985aab0","relationshipStrength":4,"relationshipTags":["t4"],"playerId":"e3aa14d3-c662-4e76-ba3b-3e1c40c3957c","playerName":"Magdalena Garnett","playerTags":[],"relationships":[{"relationshipId":"44a71855-9c28-4756-a776-8466f40d39a9","playerId":"8451f82d-943d-4338-a80e-3a2e73890358","playerName":"Harvey Alaina","relationships":[]}]}]}');
        break;
      default:
        this.network = JSON.parse('{"playerId":"05d54773-07b4-4483-8653-0b2dbe112521","playerName":"Loy Seamus","playerTags":[],"relationships":[{"relationshipId":"0998e0ef-79e8-4195-a2ad-c35335e1124f","relationshipStrength":8,"relationshipTags":["t10"],"playerId":"1ae293fa-3e50-41e6-b87e-83ef4c36aac7","playerName":"Thaddeus Nico","playerTags":[],"relationships":[{"relationshipId":"cd2283f5-fc03-4aa9-952a-34748f5106bf","playerId":"8451f82d-943d-4338-a80e-3a2e73890358","playerName":"Harvey Alaina","relationships":[{"relationshipId":"032f6925-301c-4121-a59e-e3302549e174","playerId":"aa58b458-65c7-4941-b32a-62b06c24280d","playerName":"Courtney Ulises","relationships":[{"relationshipId":"b943cad5-c37b-4a2f-93b3-2b1896c6a1ee","playerId":"8451f82d-943d-4338-a80e-3a2e73890358","playerName":"Harvey Alaina","relationships":[]}]},{"relationshipId":"830cb59d-c7fd-4d33-8db7-16597b178c00","playerId":"e3aa14d3-c662-4e76-ba3b-3e1c40c3957c","playerName":"Magdalena Garnett","relationships":[]},{"relationshipId":"cdbc217c-f363-4b7c-ad96-e594e4cb77f8","playerId":"1ae293fa-3e50-41e6-b87e-83ef4c36aac7","playerName":"Thaddeus Nico","relationships":[]}]}]},{"relationshipId":"b0ec7397-352e-4bb5-a93c-0a59d985aab0","relationshipStrength":4,"relationshipTags":["t4"],"playerId":"e3aa14d3-c662-4e76-ba3b-3e1c40c3957c","playerName":"Magdalena Garnett","playerTags":[],"relationships":[{"relationshipId":"44a71855-9c28-4756-a776-8466f40d39a9","playerId":"8451f82d-943d-4338-a80e-3a2e73890358","playerName":"Harvey Alaina","relationships":[]}]}]}');
    }
  }

  getNetwork() {
    this.showDepthSelectionForm = false;
    /*
    this.relationshipService.getNetworkFromPlayerByDepth("Elva33054057@gmail.com", this.networkDepth.value)
      .subscribe(data => {
        this.network = data;
        this.showNetworkGraph = true;
        this.initializeGraph();
        this.animate();
      })
    */
    this.getTestNetwork(this.networkDepth.value);
    this.showNetworkGraph = true;
    this.initializeGraph();
    this.animate();

  }


  network!: NetworkFromPlayerPerspectiveDto;
  scene!: THREE.Scene;
  renderer!: THREE.WebGLRenderer;
  camera!: THREE.PerspectiveCamera;
  controls!: OrbitControls;
  raycaster = new THREE.Raycaster();
  controls2!:PointerLockControls;
  labelRenderer!: CSS2DRenderer;
controls1!:FlyControls;
stats!:Stats;
   moveForward = false;
   moveBackward = false;
   moveLeft = false;
   moveRight = false;
   canJump = false;
   velocity = new THREE.Vector3();
   prevTime = performance.now();
   direction = new THREE.Vector3();
   vertex = new THREE.Vector3();
   color = new THREE.Color();
root!: THREE.Group;
  initializeGraph() {
    this.scene = new THREE.Scene();
    this.scene.background = new THREE.Color(0xffffff);


    this.renderer = new THREE.WebGLRenderer({alpha:true, antialias: true });
    this.renderer.setPixelRatio( window.devicePixelRatio );


    this.networkElement.appendChild(this.renderer.domElement);
    this.renderer.setSize(window.innerWidth, window.innerHeight);

    const miniMapCamera = new THREE.OrthographicCamera(-60, 60, 60, -60);



    this.camera = new THREE.PerspectiveCamera(40, window.innerWidth/window.innerHeight, 1, 1000000);
    this.camera.position.z = 250;
    const maxDistanceY = 60, minDistanceY = -60, maxDistanceX = 60, minDistanceX = -60;

    //let distanceFromParentNodeRatio = 1;
    let nodes: any = {};
    let playerIds: string[] = [];
    let players: any = {};
    let connections: any[] = [];

    let queue: NetworkFromPlayerPerspectiveDto[] = [this.network];
    let visited: NetworkFromPlayerPerspectiveDto[] = [];

    while (queue.length != 0) {
      let currentNode = queue.shift();
      if (currentNode) {
        visited.push(currentNode);
        if (!playerIds.includes(currentNode.playerId)) {
          playerIds.push(currentNode.playerId);
          players[currentNode.playerId] = {
            name: currentNode.playerName,
            tags: currentNode.playerTags,
          };
        }
        for (let friend of currentNode.relationships) {
          connections.push({
            playerFrom: currentNode.playerId,
            playerTo: friend.playerId
          });
          if (!visited.includes(friend) && !queue.includes(friend)) {
            queue.push(friend);
          }
        }
      }
    }

    const circleGeometry = new THREE.SphereGeometry(4, 32);
    this.labelRenderer = new CSS2DRenderer();
    this.labelRenderer.setSize( window.innerWidth, window.innerHeight );
    this.labelRenderer.domElement.style.position = 'absolute';
    this.labelRenderer.domElement.style.top = '0px';
    this.labelRenderer.domElement.style.pointerEvents = 'none';
    // @ts-ignore
    document.getElementById("container").appendChild( this.labelRenderer.domElement );


    let position = [];
let mesh_note=new Map();
    let root;
    for (let i = 0; i < playerIds.length; i++) {
      let material = new THREE.MeshBasicMaterial({color: 0x009EFA});
      let circle;
      circle =
        i == 0

          ? new THREE.Mesh(new THREE.SphereGeometry(6, 32),
            new THREE.MeshBasicMaterial({color: 0xFF8066, name: playerIds[i]}))
          : new THREE.Mesh(circleGeometry, material);


      circle.position.x = i == 0 ? 0 : Math.random() * (maxDistanceX - minDistanceX) + minDistanceX;
      circle.position.y = i == 0 ? 0 : Math.random() * (maxDistanceY - minDistanceY) + minDistanceY;
      circle.position.z = i == 0 ? 0 : Math.random() * (maxDistanceY - minDistanceY) + minDistanceY;
      mesh_note.set(circle.id, players[playerIds[i]].name);
      this.scene.add(circle);
      nodes[playerIds[i]] = circle;
      const text = document.createElement( 'div' );
      text.className = 'label';
      text.style.color = "0xFF8066";
      text.textContent = players[playerIds[i]].name;

      const label = new CSS2DObject( text );
      label.position.copy( circle.position );
      this.scene.add( label );
     // this.addLabel("              "+players[playerIds[i]].name,circle, 0xFF8066, this.camera);
    }

    const materialConnections = new THREE.LineBasicMaterial({color: 0xffffff});

    for (let connection of connections) {
      let playerfrom;
      let playerto;
      const connectionPoints: THREE.Vector3[] = [];
      for (let playerId of playerIds) {
        if (connection.playerFrom == playerId || connection.playerTo == playerId) {
          connectionPoints.push(new THREE.Vector3(nodes[playerId].position.x, nodes[playerId].position.y, nodes[playerId].position.z));
          if (connection.playerFrom == playerId && playerfrom==null){
            playerfrom=playerId;
          }
          if (connection.playerTo == playerId && playerto==null){
            playerto=playerId;
          }
          if (connectionPoints.length == 2 && playerto!=null && playerfrom!=null){
            this.createEdge(connectionPoints[0], connectionPoints[1]);
          }
          if (connectionPoints.length>1)
            break

        }
      }

    }

    this.controls = new OrbitControls(this.camera, this.renderer.domElement);
    this.controls.enableZoom = true;
    this.controls.enablePan = true;
    this.controls.enableRotate = true;
    this.controls.minZoom = 0.2;
    this.controls.maxZoom = 12;
    this.controls.zoomSpeed = 2;
    /*
        this.controls1 = new FlyControls( this.camera );
        this.controls1.movementSpeed = 10;

        this.controls1.rollSpeed = 1;
        this.controls1.autoForward = false;
        this.controls1.dragToLook = true;
    */
   // this.camera.position.set(0, 0, 2);
    this.controls.update();
   // this.controls1.update(1);
/*
    window.addEventListener('resize', () => {
<<<<<<< HEAD
      this.camera.set = window.innerWidth / - 20;
=======
      this.camera.left = window.innerWidth / -20;
>>>>>>> f6a59fb186b98d50177836b5bcaf9ea0b76ebde1
      this.camera.right = window.innerWidth / 20;
      this.camera.top = window.innerHeight / 20;
      this.camera.bottom = window.innerHeight / -20;
      this.camera.updateProjectionMatrix();
      this.renderer.setSize(window.innerWidth, window.innerHeight);
    }, false);*/



    this.controll();

    window.document.body.style.overflow = "hidden";
    //this.renderer.render(this.scene, this.camera);

  }

  goBack(): void {
    this.location.back();
  }
   onWindowResize() {
    this.camera.aspect = window.innerWidth / window.innerHeight
    this.camera.updateProjectionMatrix()
    this.renderer.setSize(window.innerWidth, window.innerHeight)
     this.renderer.render(this.scene, this.camera);
     this.labelRenderer.setSize( window.innerWidth, window.innerHeight );
this.labelRenderer.render(this.scene, this.camera);
   }
  animate() {
    requestAnimationFrame(this.animate.bind(this));
    this.controls.update();
    this.renderer.render(this.scene, this.camera);
    this.renderMiniMap();
    this.labelRenderer.render(this.scene, this.camera);
//this.controls1.update(1);

  }
controll(){

  let controls2 = new PointerLockControls(this.camera,this.renderer.domElement);
  controls2.disconnect();
   var camere=this.camera;
  const onKeyDown = function (event: KeyboardEvent) {
    switch (event.code) {
      case 'KeyW':
       // controls2.moveForward(10)
        camere.translateZ(-10);
        break
      case 'KeyA':
        //controls2.moveRight(-.1)
        camere.translateX(-10)

        break
      case 'KeyS':
        //controls2.moveForward(-10);
        camere.translateZ(10);
        break
      case 'KeyD':
        //controls2.moveRight(10)
camere.translateX(10)
        break
      case  'KeyP':

        break;
    }
  }
//this.camera=camere;
  document.addEventListener('keydown', onKeyDown, false)
  window.addEventListener('resize', this.onWindowResize, false)
  this.renderer.render(this.scene, camere);


}
  renderMiniMap() {

    const miniMapCamera = new THREE.OrthographicCamera(-60, 60, 60, -60);
    miniMapCamera.position.z = 20;

    const borderSize = 1;
    const paddingX = 55;
    const paddingY = 125;
    const BorderColor = 0x000000;

    this.renderer.setScissorTest(true);
    this.renderer.setScissor(window.innerWidth - 200 - paddingX, paddingY, 200 + (2 * borderSize),
      200 + (2 * borderSize));
    this.renderer.setClearColor(BorderColor, 1);
    this.renderer.clearColor();
    let vp: Vector4 = new Vector4;
    this.renderer.getCurrentViewport(vp);
    this.renderer.setViewport(window.innerWidth - 200 - paddingX + borderSize, paddingY + borderSize,
      200, 200);
    this.renderer.setScissor(window.innerWidth - 200 - paddingX + borderSize, paddingY + borderSize,
      200, 200);
    miniMapCamera.updateProjectionMatrix();
    this.renderer.render(this.scene, miniMapCamera);
    this.renderer.setScissorTest(false);
    this.renderer.setViewport(vp);
  }
   createEdge(position0:any, position1:any) {
    // Compute distance between nodes
    const distance = position1.distanceTo(position0);

    // Create a mesh with the specified geometry and material
    const cylinder = new THREE.Mesh(new THREE.CylinderGeometry(0.5, 0.5, 1.0), new THREE.MeshBasicMaterial({ color: 0x0000ff }));

    // Set its position
    cylinder.position.set((position0.x + position1.x) / 2.0, (position0.y + position1.y) / 2.0, (position0.z + position1.z) / 2.0);

    // Set its orientation
    const angH = Math.atan2(position1.x - position0.x, position1.z - position0.z);
    const angV = Math.acos((position1.y - position0.y) / distance);
    cylinder.rotateY(angH);
    cylinder.rotateX(angV);

    // Set its length
    cylinder.scale.set(1.0, distance, 1.0);

    // Add it to the scene
    this.scene.add(cylinder);
  }



}

