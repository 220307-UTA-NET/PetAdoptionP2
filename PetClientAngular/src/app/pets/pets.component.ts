import { Component, OnInit } from '@angular/core';

import { PetService } from '../pet.service';
import { MessageService } from '../message.service';
import { Pet } from '../pet';


@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {
  pets: Pet[] = [];
  //selectedPet: Pet = this.pets[0];
  constructor(
    private petService: PetService, 
  //  private messageService: MessageService
    ) { }

  // onSelect(pet: Pet): void {
    // this.selectedPet = pet;
    // this.messageService.add(`PetsComponent: Selected pet id=${this.selectedPet.PetId}`);
  // }
  ngOnInit(): void {
    this.getPets();
  }
  getPets(): void {
    this.petService.getPets().subscribe(pets => this.pets = pets);
  }

}


