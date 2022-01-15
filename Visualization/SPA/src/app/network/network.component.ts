import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {RelactionShipServiceService} from "../services/relaction-ship-service.service";
import {NetworkFromPlayerPerspectiveDto} from '../dto/relationships/NetworkFromPlayerPerspectiveDto';
import * as THREE from 'three';
import {OrbitControls} from 'three/examples/jsm/controls/OrbitControls';
import {Location} from "@angular/common";
import {Color, Vector2, Vector4} from "three";
import {CSS2DObject, CSS2DRenderer} from "three/examples/jsm/renderers/CSS2DRenderer";
import Stats from "three/examples/jsm/libs/stats.module";

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

    this.relationshipService.getNetworkFromPlayerByDepth("Jules46843207@gmail.com", this.networkDepth.value)
      .subscribe(data => {

        this.network = data;
        this.showNetworkGraph = true;
        this.initializeGraph();
        this.animate();
      })

    //this.getTestNetwork(this.networkDepth.value);
    //this.showNetworkGraph = true;
    //this.initializeGraph();
    //this.animate();

  }
  network!: NetworkFromPlayerPerspectiveDto;
  scene!: THREE.Scene;
  renderer!: THREE.WebGLRenderer;
  camera!: THREE.PerspectiveCamera;
  controls!: OrbitControls;
  raycaster = new THREE.Raycaster();
  labelRenderer!: CSS2DRenderer;
  stats!:Stats;
  mouse: Vector2 = new THREE.Vector2(0, 0);
  spheres:any[]=[]
  onObject:THREE.Intersection[]=[];
  objectPressed: THREE.Intersection[]=[];
  buttons:any[]=[];
  onCylinder:any[]=[]
  labelAdded: any[] = [];
  cylinders:any[]=[]
  pointlight1!:THREE.PointLight
  pointlight2!:THREE.PointLight
  initializeGraph() {

    this.scene = new THREE.Scene();
    this.scene.background =new Color("white");


    this.renderer = new THREE.WebGLRenderer({alpha:true, antialias: true });
    this.renderer.setPixelRatio( window.devicePixelRatio );


    this.networkElement.appendChild(this.renderer.domElement);
    this.renderer.setSize(window.innerWidth, window.innerHeight);

    this.camera = new THREE.PerspectiveCamera(40, window.innerWidth/window.innerHeight, 1, 1000000);
    this.camera.position.z = 250;
    const maxDistanceY = 60, minDistanceY = -60, maxDistanceX = 60, minDistanceX = -60;

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
            emotionalStatus: currentNode.emotionalStatus,

          };
        }
        for (let friend of currentNode.relationships) {

          connections.push({
            playerFrom: currentNode.playerId,
            playerTo: friend.playerId,
            relationshipStrengthDest: friend.relationshipStrengthDest,
            relationshipStrengthOrig:friend.relationshipStrengthOrig,
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



    for (let i = 0; i < playerIds.length; i++) {
      let material = new THREE.MeshStandardMaterial({color: 0x009EFA, name: playerIds[i] , metalness: 0.2,
        roughness:0.55, opacity:1.0});
      let circle;
      circle =
        i == 0

          ? new THREE.Mesh(new THREE.SphereGeometry(6, 32),
            new THREE.MeshStandardMaterial({color: 0xFF8066, name: playerIds[i] , metalness: 0.2,
              roughness:0.55, opacity:1.0}))
          : new THREE.Mesh(circleGeometry, material);


      circle.position.x = i == 0 ? 0 : Math.random() * (maxDistanceX - minDistanceX) + minDistanceX;
      circle.position.y = i == 0 ? 0 : Math.random() * (maxDistanceY - minDistanceY) + minDistanceY;
      circle.position.z = i == 0 ? 0 : Math.random() * (maxDistanceY - minDistanceY) + minDistanceY;
      circle.name=players[playerIds[i]].name;
      console.log(players[playerIds[i]].name)
      this.scene.add(circle);
      nodes[playerIds[i]] = circle;
      const text = document.createElement( 'div' );
      text.className = 'label';
      text.style.color = "0xFF8066";

      text.textContent = players[playerIds[i]].name+"      " +this.addEmots(players[playerIds[i]].emotionalStatus);

      const label = new CSS2DObject( text );
      label.position.copy( circle.position );
      this.scene.add( label );
      this.spheres.push(circle)

    }


    for (let connection of connections) {
      console.log(connection)
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

            this.createEdge(connectionPoints[0], connectionPoints[1],connection);
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
    this.controls.enableKeys=true;
this.controls.keys={
  LEFT:"KeyA",
  UP: 'KeyP', // up arrow
  RIGHT: 'KeyD', // right arrow
  BOTTOM: 'KeyL'// down arrow

}
window.addEventListener("keydown", event=>{
  switch (event.key) {
    case "w":
      this.camera.translateZ(-2);
    break;
    case "s":
      this.camera.translateZ(2);
      break;
  }
})
    this.lights()
this.controls.listenToKeyEvents(document.body);

  //  window.document.body.style.overflow = "hidden";

   // window.addEventListener( 'mousemove', this.onMouseMove, false );
    this.renderer.domElement.addEventListener("mousemove", ev => {
      this.mouse.x = (ev.clientX / window.innerWidth) * 2 - 1;
      this.mouse.y = - ( (ev.clientY - 70 ) / (window.innerHeight - 70) ) * 2 + 1;

      this.raycaster.setFromCamera(this.mouse, this.camera);
      this.checkIntersects();
      this.checkIntersectsConnections();
    })

  this.renderer.domElement.addEventListener("click", event=>{
    this.clickfunction();
      });
  }


  clickfunction(){
    if (this.onObject.length>0){
      if(!((<THREE.Mesh>this.onObject[0].object).position.x == 0 && (<THREE.Mesh>this.onObject[0].object).position.y == 0)){
        if (this.objectPressed.length > 0 && (<THREE.Mesh>this.onObject[0].object).position != (<THREE.Mesh>this.objectPressed[0].object).position){
          (<THREE.MeshBasicMaterial>(<THREE.Mesh>this.objectPressed[0].object).material).color.set(0x2e86c1);
          for(let button of this.buttons) {
            (<THREE.Mesh>this.objectPressed[0].object).remove(button);
          }
        }
        this.objectPressed = this.onObject;
        const button= document.createElement( 'button' );
        button.className = 'btn btn-secondary';

        button.addEventListener("click",event=>{
          console.log("strongt")


        })
        button.textContent = "path";
        button.style.color = '0x000';
        const buttonObject = new CSS2DObject( button );
        this.buttons.push(buttonObject);
        (<THREE.Mesh>this.objectPressed[0].object).add(buttonObject);
      }
    }else {
      if(this.objectPressed.length > 0) {
        if(!((<THREE.Mesh>this.objectPressed[0].object).position.x == 0 && (<THREE.Mesh>this.objectPressed[0].object).position.y == 0)) {
          (<THREE.MeshBasicMaterial>(<THREE.Mesh>this.objectPressed[0].object).material).color.set(0x2e86c1);
          for(let button of this.buttons) {
            (<THREE.Mesh>this.objectPressed[0].object).remove(button);
          }
        }
        this.objectPressed = [];
      }
    }
  }


addEmots(emocionalStatus:string):string{

    let result="";
    switch (emocionalStatus) {
      case "NotSpecified":
        result="NotSpecified";
        break;
      case "Joyful":
        result="😊";
        break;
      case "Distressed":
        result="😩";
        break;
      case "Hopeful":
        result="(θ‿θ)";
        break;
      case "Fearful":
        result="😨";
        break;
      case "Relieve":
        result="😌";
        break;
      case "Disappointed":
        result="😞";
        break;
      case "Proud":
        result="";
        break;
      case "Remorseful":
        result="(*´-｀*)";
        break;
      case "Grateful":
        result="🤗";
        break;
      case "Angry":
        result="😡";
        break;
      default:
        result="NotSpecified";
        break;
    }
    return result;
}

  checkIntersects(){
    const intersection=this.raycaster.intersectObjects( this.spheres );
    if(this.onObject.length > 0 && intersection != this.onObject) {
      for(let obj of this.onObject) {
        if(!this.objectPressed.some(x => x.object.position == obj.object.position)) {
          if(!((<THREE.Mesh>obj.object).position.x == 0 && (<THREE.Mesh>obj.object).position.y == 0)) {
            (<THREE.MeshBasicMaterial>(<THREE.Mesh>obj.object).material).color.set(0x2e86c1);
          }
        }
      }
    }
    this.onObject = intersection;
    for(let inter of intersection) {
      if(!((<THREE.Mesh>inter.object).position.x == 0 && (<THREE.Mesh>inter.object).position.y == 0)) {
        (<THREE.MeshBasicMaterial>(<THREE.Mesh>inter.object).material).color.set(0xff0000);
      }
    }

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
  }

  lights(){
    this.pointlight1= new THREE.PointLight( new Color("white"), 0.5);
    this.pointlight1.position.set( -500, 500, 50 );
    this.scene.add( this.pointlight1 );
    this.pointlight2= new THREE.PointLight( new Color("white"), 0.5);
    this.pointlight2.position.set( 500, -500, 50 );
    this.scene.add( this.pointlight2 );
    const color = 0xFFFFFF;
    const intensity = 1.2;
    const light = new THREE.AmbientLight(
      color, intensity
    );
    this.scene.add(light);
    const lightbackground=new THREE.SpotLight(new Color("white"), 0.7);
    lightbackground.target=this.camera;
    lightbackground.angle=THREE.MathUtils.degToRad(10);
    lightbackground.penumbra=0.4;
    lightbackground.position.z=250;
    this.camera.add(lightbackground);
    this.scene.add(this.camera)
  }

  renderMiniMap() {
    const miniMapCamera = new THREE.OrthographicCamera(-60, 60, 60, -60);
    miniMapCamera.position.z = 250;

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


   createEdge(position0:any, position1:any, connection:any) {
    // Compute distance between nodes
    const distance = position1.distanceTo(position0);

    // Create a mesh with the specified geometry and material 0x0000ff
    const cylinder = new THREE.Mesh(new THREE.CylinderGeometry(0.5, 0.5, 1.0), new
    THREE.MeshStandardMaterial({ color: new Color("blue") , metalness:0.2,roughness:0.55, opacity:1.0    }));

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
    this.cylinders.push({
       cylinderobject: cylinder,
       connection:connection
     })
    this.scene.add(cylinder);

  }
  checkIntersectsConnections() {
    if(this.onObject.length > 0) {
      if(this.onCylinder.length > 0) {
        for(let obj of this.onCylinder) {
          (<THREE.MeshBasicMaterial>(<THREE.Mesh>obj.object).material).color.set(0x80ffff);
          for(let label of this.labelAdded) {
            (<THREE.Mesh>obj.object).remove(label);
          }
        }
      }
      this.onCylinder = [];
      return;
    }
    let cyls = [];
    for(let cylinder of this.cylinders) {
      cyls.push(cylinder.cylinderobject);
    }
    const intersects = this.raycaster.intersectObjects( cyls );
    if(this.onCylinder.length > 0 && intersects != this.onCylinder) {
      for(let obj of this.onCylinder) {
        (<THREE.MeshBasicMaterial>(<THREE.Mesh>obj.object).material).color.set(new Color("blue"));
        for(let label of this.labelAdded) {
          (<THREE.Mesh>obj.object).remove(label);
        }
      }
    }
    this.onCylinder = intersects;
    for(let inter of intersects) {
      (<THREE.MeshBasicMaterial>(<THREE.Mesh>inter.object).material).color.set(new Color("blue"));
      let con;
      for(let cylinder of this.cylinders) {
        if(cylinder.cylinderobject.position == (<THREE.Mesh>inter.object).position) {
          con = cylinder;
          break;
        }
      }

      const label = document.createElement( 'div' );
      label.className = 'badge bg-warning text-wrap';
      label.style.width = "8rem";
      label.textContent = "Strength Dest: " + con?.connection.relationshipStrengthDest +" Strength Origin: "+con?.connection.relationshipStrengthOrig;
      const labelCylinderObject = new CSS2DObject( label );
      labelCylinderObject.position.setZ( 2 );
      this.labelAdded.push(labelCylinderObject);
      (<THREE.Mesh>inter.object).add(labelCylinderObject);
    }
  }
}

