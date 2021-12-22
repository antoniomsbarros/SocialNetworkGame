import {Injectable} from '@angular/core';
import {NavbarComponent} from "../../ViewModel/NavbarComponent";

@Injectable({
  providedIn: 'root'
})
export class HeaderService {

  private availableComponents: NavbarComponent[] = [];

  constructor() {
  }

  getComponents(): any[] {
    return this.availableComponents;
  }

  setComponents(components: any[]): void {
    this.availableComponents = components;
  }

  addComponent(component: any): boolean {
    const componentIndex = this.availableComponents.indexOf(component, 0);

    if (componentIndex != -1) // verifies if the component is not already in the array
      return false;

    this.availableComponents.push(component);
    return true;
  }

  removeComponent(component: any): boolean {
    const componentIndex = this.availableComponents.indexOf(component, 0);

    if (componentIndex == -1) // verifies if the component exists in the array
      return false;

    this.availableComponents.splice(componentIndex, 1);

    return true;
  }

}
