import { Component, OnInit, Input } from '@angular/core';

// following import is for the pet-detail component routing
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { PetService } from '../pet.service';

import { Pet } from '../pet';

@Component({
  selector: 'app-pet-detail',
  templateUrl: './pet-detail.component.html',
  styleUrls: ['./pet-detail.component.css']
})
export class PetDetailComponent implements OnInit {
  //@Input() selectedPet?: Pet;
  selectedPet?: Pet;
  constructor(
    private route: ActivatedRoute,
    private petService: PetService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getPet();
  }
  getPet(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.petService.getPet(id)
      .subscribe(pet => this.selectedPet = pet);
  }
  goBack(): void {
    this.location.back();
  }
}
