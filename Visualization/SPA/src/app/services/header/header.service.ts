import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {

  private availableComponents: string[] = ['Home'];

  constructor() {
  }

  getComponents(): string[] {
    return this.availableComponents;
  }

  setComponents(components: string[]): void {
    this.availableComponents = components;
  }

  addComponent(component: string): boolean {
    const componentIndex = this.availableComponents.indexOf(component, 0);

    if (componentIndex != -1) // verifies if the component is not already in the array
      return false;

    this.availableComponents.push(component);
    return true;
  }

  removeComponent(component: string): boolean {
    const componentIndex = this.availableComponents.indexOf(component, 0);

    if (componentIndex == -1) // verifies if the component exists in the array
      return false;

    this.availableComponents.splice(componentIndex, 1);

    return true;
  }


}
