import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {RelactionShipServiceService} from "../services/relaction-ship-service.service";
import {NetworkFromPlayerPerspectiveDto} from '../dto/relationships/NetworkFromPlayerPerspectiveDto';
import * as THREE from "three";
import {OrbitControls} from 'three/examples/jsm/controls/OrbitControls';
import {TextGeometry} from 'three/examples/jsm/geometries/TextGeometry';
import {FontLoader} from 'three/examples/jsm/loaders/FontLoader';


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


  constructor(public relationshipService: RelactionShipServiceService) {
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
  camera!: THREE.OrthographicCamera;
  controls!: OrbitControls;

  initializeGraph() {
    this.scene = new THREE.Scene();
    this.scene.background = new THREE.Color(0xc9aa88);

    this.renderer = new THREE.WebGLRenderer({ antialias: true });
    this.renderer.setPixelRatio( window.devicePixelRatio );

    this.networkElement.appendChild(this.renderer.domElement);
    this.renderer.setSize(window.innerWidth, window.innerHeight);

    const miniMapCamera = new THREE.OrthographicCamera(-60, 60, 60, -60);
    miniMapCamera.position.z = 10;

    this.camera = new THREE.OrthographicCamera(window.innerWidth / - 20, window.innerWidth / 20,
      window.innerHeight / 20, window.innerHeight / - 20, 1, 1000);

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
            tags: currentNode. playerTags
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

    const circleGeometry = new THREE.CircleGeometry(4, 32);

    for (let i = 0; i < playerIds.length; i++) {
      let material = new THREE.MeshBasicMaterial({ color: 0x009EFA });

      let circle =
        i == 0
        ? new THREE.Mesh(new THREE.CircleGeometry(6, 32),
            new THREE.MeshBasicMaterial({ color: 0xFF8066 }))
        : new THREE.Mesh(circleGeometry, material);

      circle.position.x = i == 0 ? 0 : Math.random() * (maxDistanceX - minDistanceX) + minDistanceX;
      circle.position.y = i == 0 ? 0 : Math.random() * (maxDistanceY - minDistanceY) + minDistanceY;
      circle.position.z = 0;

      this.scene.add(circle);
      nodes[playerIds[i]] = circle;
    }

    const materialConnections = new THREE.LineBasicMaterial({ color: 0xffffff });
    for (let connection of connections) {
      const connectionPoints: THREE.Vector3[] = [];
      for (let playerId of playerIds) {
        if (connection.playerFrom == playerId || connection.playerTo == playerId) {
          connectionPoints.push(new THREE.Vector3(nodes[playerId].position.x, nodes[playerId].position.y, -0.5));
          if (connectionPoints.length > 1)
            break;
        }
      }
      const geometryConnections = new THREE.BufferGeometry().setFromPoints(connectionPoints);
      const line = new THREE.Line(geometryConnections, materialConnections);
      this.scene.add(line);
    }



    new FontLoader().load( 'assets/fonts/helvetiker_regular.typeface.json', font => {
      for (let playerId of playerIds) {
        let textsShapes = font.generateShapes(players[playerId].name, 1);
        let textsGeometry = new THREE.ShapeBufferGeometry( textsShapes );
        let textsMaterial = new THREE.MeshBasicMaterial({ color: 0xeeeeee });

        let text = new THREE.Mesh(textsGeometry, textsMaterial);
        text.position.set(nodes[playerId].position.x - 4, nodes[playerId].position.y, 0.5);
        this.scene.add(text);
      }
    });

    this.controls = new OrbitControls(this.camera, this.renderer.domElement);
    this.controls.enableZoom = true;
    this.controls.enablePan = true;
    this.controls.enableRotate = false;
    this.controls.minZoom = 0.2;
    this.controls.maxZoom = 12;
    this.controls.zoomSpeed = 2;

    this.camera.position.set(0, 0, 2);

    this.controls.update();

    window.addEventListener('resize', () => {
      this.camera.left = window.innerWidth / - 20;
      this.camera.right = window.innerWidth / 20;
      this.camera.top = window.innerHeight / 20;
      this.camera.bottom = window.innerHeight / -20;
      this.camera.updateProjectionMatrix();
      this.renderer.setSize(window.innerWidth, window.innerHeight);
    }, false);

    window.document.body.style.overflow = "hidden";
    this.renderer.render( this.scene, this.camera );
/*
    // Create Square
    this.renderer.setScissorTest(true);
    this.renderer.setScissor(window.innerWidth - 221, 100, 202, 202);
    //this.renderer.setClearColor(0x000000, 1); // border color
   // this.renderer.clearColor();

    // Create Mini-Graph

    this.renderer.setViewport(window.innerWidth - 221, 101, 200, 200);
    this.renderer.setScissor(window.innerWidth - 220, 101, 200, 200);
    this.renderer.setScissorTest(true);
    miniMapCamera.updateProjectionMatrix();
    this.renderer.render(this.scene, miniMapCamera);*/



  }


  animate() {
    requestAnimationFrame(this.animate.bind(this));
    this.controls.update();
    this.renderer.render(this.scene, this.camera);
  }

}
