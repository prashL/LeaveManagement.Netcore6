using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementWeb_Core_6.Data;
using AutoMapper;
using LeaveManagementWeb_Core_6.Models;
using LeaveManagementWeb_Core_6.Repositories;
using LeaveManagementWeb_Core_6.Contracts;

namespace LeaveManagementWeb_Core_6.Controllers
{
    public class LeaveTypesController : Controller
    {        
        private readonly LeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public LeaveTypesController(LeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        //Mapping using AutoMapper
        public async Task<IActionResult> Index()
        {
            var LeaveTypes = _mapper.Map<List<LeaveTypeVM>>(await _leaveTypeRepository.GetAllAsync());
            return View(LeaveTypes);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {                       
            var leaveType = await _leaveTypeRepository.GetAsync(id);// _context.LeaveTypes.FindAsync(id);
            var LeaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(LeaveTypeVM);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DefaultDays,Id")] LeaveTypeVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var LeaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                await _leaveTypeRepository.AddAsync(LeaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);// _context.LeaveTypes.FindAsync(id);
            var LeaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(LeaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,DefaultDays,Id")] LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }
          
            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                    await _leaveTypeRepository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await  _leaveTypeRepository.Exists(leaveTypeVM.Id))// LeaveTypeExists(leaveTypeVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            var leaveType = await _leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            await _leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private async Task<bool> LeaveTypeExists(int id)
        //{
        //    return await _leaveTypeRepository.Exists(id);
        //}
    }
}
