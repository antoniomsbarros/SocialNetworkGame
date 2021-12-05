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


  getNetwork() {
    this.showDepthSelectionForm = false;
    this.relationshipService.getNetworkFromPlayerByDepth("Elva33054057@gmail.com", this.networkDepth.value)
      .subscribe(data => {
        this.network = data;
        this.showNetworkGraph = true;
        this.initializeGraph();
        this.animate();
      })
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


    this.camera = new THREE.OrthographicCamera(window.innerWidth / - 20, window.innerWidth / 20,
      window.innerHeight / 20, window.innerHeight / - 20, 1, 1000);

    const maxDistanceY = 40, minDistanceY = -40, maxDistanceX = 40, minDistanceX = -40;

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
      let material = new THREE.MeshBasicMaterial({ color: Math.floor(Math.random() * 0xffffff) });

      let circle =
        i == 0
        ? new THREE.Mesh(new THREE.CircleGeometry(6, 32), material)
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
    this.controls.minZoom = 1;
    this.controls.maxZoom = 12;

    this.camera.position.set(0, 0, 2);

    this.controls.update();

    window.addEventListener('resize', this.onWindowResize, false);
    window.document.body.style.overflow = "hidden";
  }

  onWindowResize() {
    this.camera.updateProjectionMatrix();
    this.renderer.setSize(window.innerWidth, window.innerHeight);

  }

  animate() {
    requestAnimationFrame(this.animate.bind(this));
    this.controls.update();
    this.renderer.render(this.scene, this.camera);
  }

}
